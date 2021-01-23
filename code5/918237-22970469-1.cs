    List<Blog> result = context.Blogs
        .GroupBy(b => new { b.Created.Year, b.Created.Month, b.Created.Day })
        .OrderByDescending(g => g.Key.Year)
        .ThenByDescending(g => g.Key.Month)
        .ThenByDescending(g => g.Key.Day)
        .Skip((page - 1) * daysPerPage)
        .Take(daysPerPage)
        .SelectMany(g => g)
        .OrderByDescending(b => b.Created)
        .ToList();
