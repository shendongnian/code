    Dictionary<string, int> MergeSum(Dictionary<string, int>[] dictionaries)
    {
        Dictionary<string, int> merged = new Dictionary<string, int>();
        foreach (Dictionary<string, int> dict in dictionaries)
        {
            foreach (var kvp in dict)
            {
                int value;
                merged.TryGetValue(kvp.Key, out value);
                merged[kvp.Key] = kvp.Value + value;
            }
        }
    }
