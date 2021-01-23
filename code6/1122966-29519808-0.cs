    var groupResult =
        await collection
            .Aggregate()
            .Group(
                x => x.PartnerId,
                g => new
                {
                    PartnerId = g.Key,
                    Description = g.First(x => x.Description != null).Description,
                    Discounts = g.Select(x => x.Discounts)
                })
            .ToListAsync();
            
    var result =
        groupResult
            .Select(x =>
                new GroupProjection
                {
                    PartnerId = x.PartnerId,
                    Description = x.Description,
                    Discounts = x.Discounts.SelectMany(d => d)
                })
            .ToList();
