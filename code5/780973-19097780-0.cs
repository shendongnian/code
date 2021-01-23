    var posts = dbContext
        .Posts
        .Where(x => channels.Contains(x.Connection))
        .GroupBy(p => new { p.Medium, p.ID })
        .Select(g => g.FirstOrDefault()) // gives the first Post in each group
        .OrderByDescending(x => x.Date)
        .Skip(skip)
        .Take(take);
