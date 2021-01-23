    var originalArray = new[] { 1, 2, 1, 1, 3, 2, 1, 2, 4, 4 };
    var repeats = originalArray.GroupBy(i => i)
                               .Where(g => g.Count() >= 2)
                               .ToDictionary(t => t.Key, t => t.Count());
    // output: a dictionary with 3 key/value pairs (1/4 , 2/3 , 4/2)
