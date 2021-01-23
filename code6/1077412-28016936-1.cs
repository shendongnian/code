    Dictionary<string, int> MergeSum(
        Dictionary<string, int> dict1, Dictionary<string, int> dict2)
    {
        Dictionary<string, int> merged = new Dictionary<string, int>(dict1.Count);
        foreach (var kvp in dict1)
        {
            int value;
            dict2.TryGetValue(kvp.Key, out value);
            merged.Add(kvp.Key, kvp.Value + value);
        }
        foreach (var kvp in dict2)
        {
            int value;
            if (!dict1.TryGetValue(kvp.Key, out value))
            {
                merged.Add(kvp.Key, kvp.Value);
            }
        }
    }
