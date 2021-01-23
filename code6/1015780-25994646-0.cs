    public static Dictionary<T, int> ToDictionaryCount<T>(this IDictionary<T, int> dico)
    {
        if (dico == null)
            throw new ArgumentNullException("dico");
        var result = dico.GroupBy(arg => arg.Key)
            .ToDictionary(g => g.Key, g => g.Select(pair => pair.Value).Sum())
            .Where(pair => pair.Value == 0)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
            
        return result;
    }
