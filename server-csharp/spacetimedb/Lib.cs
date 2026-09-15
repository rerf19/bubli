using SpacetimeDB;

public static partial class Module
{
    // Config table
    [Table(Name = "config", Public = true)]
    public partial struct Config
    {
        [PrimaryKey]
        public uint id;
        public ulong world_size;
    }

    [SpacetimeDB.Type]
    public partial struct DbVector2
    {
        public float x;
        public float y;
        
        public DbVector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [Table(Name = "entity", Public = true)]
    public partial struct Entity
    {
        [PrimaryKey,AutoInc]
        public uint entity_id;
        public DbVector2 position;
        public uint mass;

    }

    [Table(Name = "circle", Public = true)]
    public partial struct Circle
    {
        [PrimaryKey]
        public uint entity_id;
        [SpacetimeDB.Index.BTree]
        public uint player_id;
        public DbVector2 position;
        public float speed;
        public ulong last_split_time;
        
    }

    [Table(Name = "food", Public = true)]
    public partial struct Food
    {
        [PrimaryKey]
        public uint entity_id;
    }

    [Table(Name = "player", Public = true)]
    public partial struct Player
    {
        [PrimaryKey]
        public Identity identity;
        [Unique, AutoInc]
        public uint player_id;
        public string name;
        
    }

    [Reducer]
    public static void Debug(ReducerContext ctx)
    {
        Log.Info($"This reducer was called by {ctx.Sender}");
    }
}