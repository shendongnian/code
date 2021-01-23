    // sample data
    Dictionary<string, string> a = new Dictionary<string, string>();
    a.Add("A", "B"); a.Add("C", "D");
    Dictionary<string, string> b = new Dictionary<string, string>();
    b.Add("A", "Z"); b.Add("E", "D");
    // first, reverse dictionary A for simplicity
    // to quickly get the key for a value
    var revA = a.ToDictionary(kv => kv.Value, kv => kv.Key);
    // and then compute the result
    var result = b.Where(kv => revA.ContainsKey(kv.Value) && revA[kv.Value] != kv.Key)
                  .ToDictionary(kv => kv.Key, kv => kv.Value);
