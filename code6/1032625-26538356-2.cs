    var list = Enumerable.Range(1, 1000).ToList();
    
    List<List<int>> groupsOf4 = list
        .Select((num, index) => new { num, index })
        .GroupBy(x => x.index / 4).Select(g => g.Select(x => x.num).ToList())
        .ToList();  // 250 groups of 4
