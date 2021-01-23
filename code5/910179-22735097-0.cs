    var source = new List<List<int>> {
        new List<int> { 3, 5, 1 },
        new List<int> { 5, 1, 8 },
        new List<int> { 3, 3, 3 },
        new List<int> { 2, 0, 4 }
    };
    var maxes = source.SelectMany(x => x.Select((v, i) => new { v, i }))
                      .GroupBy(x => x.i, x => x.v)
                      .OrderBy(g => g.Key)
                      .Select(g => g.Max())
                      .ToList();
