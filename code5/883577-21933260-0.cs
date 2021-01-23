    public static void AddOrKeep<K, V>(this IDictionary<K, V> dictionary, K key, V val)
    {
        if (!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, val);
        }
    }
