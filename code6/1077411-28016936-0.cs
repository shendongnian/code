    Dictionary<string, int> MergeSum(
        Dictionary<string, int> dict1, Dictionary<string, int> dict2)
    {
        Dictionary<string, int> merged = new Dictionary<string, int>(dict1.Count);
        foreach (var kvp in dict1)
        {
            merged.Add(kvp.Key, kvp.Value + dict2[kvp.Key]);
        }
    }
