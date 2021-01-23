    var actualPositionsFound = new[] { 100, 50, 200 };
    var indices = actualPositionsFound.OrderBy(n => n)
                                      .Select((n, i) => new { n, i })
                                      .ToDictionary(o => o.n, o => o.i);
    var result = actualPositionsFound.Select(n => indices[n]).ToList();
