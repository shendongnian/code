    var days = stays
        .SelectMany(s =>
            Enumerable.Range(0, (s.ToDate - s.FromDate).Days + 1)
            .Select(d => s.FromDate.AddDays(d)))
        .GroupBy(d => d.Year)
        .Select(s => new { s.Key, days = s.Count() })
        .ToList();
