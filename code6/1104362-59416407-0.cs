    public static async Task<Dictionary<TKey, List<T>>> ToDictionaryOfLists<T, TKey>(
        IObservable<T> source,
        Func<T, TKey> keySelector)
    {
        var lookup = await source.ToLookup(keySelector);
        return lookup.ToDictionary(g => g.Key, g => g.ToList());
    }
