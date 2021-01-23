     var enableIds = context.items.Where(tble => tble.Date == null)
                         .GroupBy(a => a.Id)
                         .Select(g => new
        {
            Id = g.Key,
            EId = g.Select(c => c.EId).Distinct().Concat(new[] { -1 })
        });
