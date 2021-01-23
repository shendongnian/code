    var top10Persons = projects
        .SelectMany(p=> p.Sponsors)
        .GroupBy(p => p)
        .OrderByDescending(g => g.Count())
        .Take(10)
        .Select(g => g.First());
