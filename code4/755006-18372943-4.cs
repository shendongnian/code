    var result = items
        .GroupBy(x => 1)
        .Select(g => new Item {
             Id = 1,
             Date = g.Min(g => g.Date),
             Comment = g.Max(g => g.Comment)
         })
        .First();
