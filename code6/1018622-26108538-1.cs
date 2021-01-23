    var sql = Sql.Builder
           .Append("SELECT c.*,e.*,f.*")
           .Append("FROM [Character] c")
           .Append("INNER JOIN [Entity] e ON e.Id = c.EntityId")
           .Append("INNER JOIN [Faction] f ON f.Id = e.FactionId")
           .Append("WHERE c.UserId = @0", 1)");
           
    var characters = db.Query<Character, Entity, Faction, Faction>(
           (c, e, f) => { f.Entity = e; e.Character = c; return f;}, sql);
       
