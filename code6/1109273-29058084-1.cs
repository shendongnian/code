    public Dictionary<int, Func<int>> Magic(Dictionary<int, int> dictionary)
    {
        return dictionary
            .ToDictionary<KeyValuePair<int, int>, int, Func<int>>(
				v => v.Key, 
				v => () => v.Value + 5);
    }
