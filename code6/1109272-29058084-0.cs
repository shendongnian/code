    public Dictionary<int, Func<int>> Magic(Dictionary<int, int> dictionary)
    {
        return dictionary
            .ToDictionary(v => v.Key, v => (Func<int>)(() => v.Value + 5));
    }
