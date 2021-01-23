    Dictionary<DataType, String[]> d = items
        .GroupBy(x => x.Item1)
        .ToDictionary(
            g => g.Key,
            g => g.Select(t => t.Item2).ToArray()); //the change is on this line
