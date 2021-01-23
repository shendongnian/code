    public static TValue GetOrAdd<TKey, TValue>(
        this Dictionary<TKey, TValue> dictionary,
        TKey key,
        TValue newValue)
    {
        TValue oldValue;
        if (dictionary.TryGetValue(key, out oldValue))
            return oldValue;
        else
        {
            dictionary.Add(key, newValue);
            return newValue;
        }
    }
