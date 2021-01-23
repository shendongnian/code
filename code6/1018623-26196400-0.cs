    public partial class Character
    {
        [ResultColumn]
        public Entity Entity { get; set; }
    }
    public partial class Entity 
    {
        [ResultColumn]
        public Faction Faction { get; set; }
    }
    sql = Sql.Builder
        .Append("SELECT c.*,e.*,f.*")
        .Append("FROM [Character] c")
        .Append("INNER JOIN [Entity] e ON e.Id = c.EntityId")
        .Append("INNER JOIN [Faction] f ON f.Id = e.FactionId")
        .Append("WHERE c.UserId = @0", 1);
    var characters = db.Fetch<Character, Entity, Faction, Character>(
        (c, e, f) => { c.Entity = e; e.Faction = f; return c; }, sql);
