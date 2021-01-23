    int groupSize = 3;
    var pages = new List<string> { "A", "B", "C", "D", "E", "F", "G" };
    List<List<string>> lists = pages
        .Select((str, index) => new { str, index })
        .GroupBy(x => x.index / groupSize)
        .Select(g => g.Select(x => x.str).ToList())
        .ToList();
