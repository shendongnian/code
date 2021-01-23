    public static TValue GetOrAdd<TKey, TValue>(
        this Dictionary<TKey, TValue> dictionary,
        TKey key)
        where TValue : new()
    {
        TValue oldValue;
        if (dictionary.TryGetValue(key, out oldValue))
            return oldValue;
        else
        {
            var newValue = new TValue();
            dictionary.Add(key, newValue);
            return newValue;
        }
    }
