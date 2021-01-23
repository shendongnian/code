    var arrs = new[] { arr1, arr2, arr3, arr4, arr5, arr6 };
    var intermediate = arrs.SelectMany(a => a)
                           .GroupBy(x => x)
                           .Select(g => new { g.Key, Count = g.Count() })
                           .OrderByDescending(x => x.Count);
    var maxCount = intermediate.First().Count;
    var results = intermediate.TakeWhile(x => x.Count == maxCount);
