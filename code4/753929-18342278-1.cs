    List<List<int>> Some2dList = new List<List<int>>{ 
            new List<int> { 1, 2, 3, 4, 5 }, 
            new List<int> { 5, 4, 3, 2, 1 },
            new List<int> { 8, 9 } 
            };
    var res = Some2dList.Select(list => list.Select((i, inx) => new { i, inx }))
                .SelectMany(x => x)
                .GroupBy(x => x.inx)
                .Select(g => g.Max(y=>y.i))
                .ToList();
