    var days = stays.SelectMany(s =>
            Enumerable
                .Range(0, (s.ToDate - s.FromDate).Days + 1)
                .Select(d => s.FromDate.AddDays(d)))
        .GroupBy(d => d.Year)
        .Select(s => new { Year = s.Key, TotalDays = s.Count() })
        .ToList();
    days.ForEach(d =>
    {
        Console.WriteLine("{0} {1}", d.Year, d.TotalDays);
    });
