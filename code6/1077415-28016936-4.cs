    Dictionary<string, int> Merge(
        Dictionary<string, int>[] dictionaries, Func<int, int, int> mergeFunction)
    {
        Dictionary<string, int> merged = new Dictionary<string, int>(dictionaries.First());
        foreach (Dictionary<string, int> dict in dictionaries.Skip(1))
        {
            foreach (var kvp in dict)
            {
                int value;
                merged.TryGetValue(kvp.Key, out value);
                merged[kvp.Key] = mergeFunction(value, kvp.Value);
            }
        }
    }
