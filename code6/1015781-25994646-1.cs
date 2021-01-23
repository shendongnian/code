    public static Dictionary<T, int> ToDictionaryCount<T>(this List<Tuple<T, int>> list)
    {
        if (list == null)
            throw new ArgumentNullException("list");
        var result = list
            .ToDictionary(x => x.Item1, x => x.Item2)
            .GroupBy(arg => arg.Key)
            .ToDictionary(g => g.Key, g => g.Select(pair => pair.Value).Sum())
            .Where(pair => pair.Value == 0)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
            
        return result;
    }
