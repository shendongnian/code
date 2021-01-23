    public static void AddMany<TKey1, TKey2, TKey3, TValue>(
        this Dictionary<TKey1, Dictionary<TKey2, Dictionary<TKey3, TValue>>> dictionary,
        TKey1 key1,
        TKey2 key2,
        TKey3 key3,
        TValue newValue)
    {
        dictionary.GetOrAdd(key1).GetOrAdd(key2)[key3] = newValue;
    }
