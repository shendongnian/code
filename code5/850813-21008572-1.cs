    Feature[] features = ...
    var results =
        from f in features
        where f.Price != 0
        group f by new { f.Id, f.Class } into g
        select new Feature 
        {
            Id = g.Key.Id,
            Class = g.Key.Class,
            Description = g.First().Description,
            Price = g.Sum(f => f.Price)
        };
