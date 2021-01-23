    var arr = new [,] { { 0, 0, 0, 0, 1 }, { 1, 1, 1, 1, 0 }, { 0, 0, 1, 1, 1 }, { 1, 0, 1, 0, 1 } };
    
    var data =
        Enumerable.Range(0, 4)
            .Select(
                row =>
                    new
                    {
                        index = row,
                        count = Enumerable.Range(0, 5).Select(col => arr[row, col]).Count(x => x == 1)
                    })
            .OrderByDescending(x => x.count)
            .Select(x => x.index)
            .First();
