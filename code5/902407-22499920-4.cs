      Dictionary<DateTime, int> oldDict = new Dictionary<DateTime, int>() {
        {new DateTime(1999, 1, 25), 1},
        {new DateTime(1999, 2, 25), 2}, // <- These values should be added up
        {new DateTime(1999, 2, 27), 3}, // <- These values should be added up
        {new DateTime(1999, 3, 25), 4},
        {new DateTime(1999, 4, 25), 5},
      };
    
      Dictionary<DateTime, int> aggregatedDict = 
        oldDict.GroupBy(pair => new DateTime(pair.Key.Year, pair.Key.Month, 1),
                        pair => pair.Value)
               .ToDictionary(x => x.Key,
                             x => x.Aggregate(0, (sum, item) => sum + item));
