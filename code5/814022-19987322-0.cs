    if (collection == null)
    {
        return new List<Dictionary<string, object>>();
    }
    return collection.Select(e => new DynamicDictionary(e));
