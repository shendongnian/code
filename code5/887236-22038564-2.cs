    var keysList = new HashSet<string>(first.List.Select(kv => kv.Key));
    var valuesList = new HashSet<string>(first.List.Select(kv => kv.Value));
    var keysDict = new HashSet<string>(second.Dictionary.Values.Select(kv => kv.Key));
    var valuesDict = new HashSet<string>(second.Dictionary.Values.Select(kv => kv.Value));
    bool sameKeys = valuesList.SetEquals(keysDict);
    bool sameValues = keysList.SetEquals(valuesDict);
