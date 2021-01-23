    double[] test = { 0.2, 1.4, 2.45, 3.66, 4.34, 5.8, 6.9, 7.56, 8.899, 9.232, 10.1, 11.1, 12.45, 13.87, 14.8, 15.78 };
    var numberOfArrays = 3;
    
    var sublists = test.Select((i, idx) => new { Item = i, Index = idx })
                .GroupBy(x => x.Index % numberOfArrays)
                .Select(g => g.Select(x => x.Item).ToArray())
                .ToList();
