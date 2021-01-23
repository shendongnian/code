    var results = features
        .Where(f => f.Price != 0)
        .GroupBy(f => new { f.Id, f.Class })
        .Select(g => new Feature 
            {
                Id = g.Key.Id,
                Class = g.Key.Class,
                Description = g.First().Description,
                Price = g.Sum(f => f.Price)
            });
