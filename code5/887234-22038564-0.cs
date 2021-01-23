    var keys = new HashSet<string>(first.List.Select(kv => kv.Key));
    var values = new HashSet<string>(first.List.Select(kv => kv.Value));
    bool sameKeys = keys.Count <= second.Dictionary.Values.Count 
        &&  second.Dictionary.Values.All(kv => keys.Contains(kv.Key));
    bool sameValues = values.Count <= second.Dictionary.Values.Count 
        && second.Dictionary.Values.All(kv => values.Contains(kv.Value));
