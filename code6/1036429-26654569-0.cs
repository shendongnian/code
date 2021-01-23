    private static object AppendSomehow(object data, object additional)
    {
        var originalDictionary = new RouteValueDictionary(original);
        var additionalDictionary = new RouteValueDictionary(additional);
    
        foreach (var kv in additionalDictionary)
            originalDictionary.Add(kv.Key, kv.Value);
    
        return new Dictionary<string, object>(originalDictionary);
    }
