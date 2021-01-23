    public static Dictionary<TK, TV> GetDictionary(ICollection<TK> keys)
    {
        var result = new Dictionary<TK, TV>(keys.Count);
        ...
        return result;
    }
