    Dictionary<string, int> d1 = new Dictionary<string, int>();
    Dictionary<string, int> d2 = new Dictionary<string, int>();
    var difference = d1.Join(d2, pair => pair.Key, pair => pair.Key, (a, b) => new
    {
        Key = a.Key,
        Value = a.Value - b.Value,
    })
    .Where(pair => pair.Value > 0)
    .ToDictionary(pair => pair.Key, pair => pair.Value);
