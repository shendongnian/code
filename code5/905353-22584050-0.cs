    public static Dictionary<K, V> DictionaryFromArrays<K, V>(K[] keys, V[] values, bool safeMode = true)
    {
        if (keys == null) throw new ArgumentNullException("keys");
        if (values == null) throw new ArgumentNullException("values");
        if(keys.Length != values.Length) throw new ArgumentException("Keys and Values must have the same length!");
        
        if (!safeMode)
            return keys.Zip(values, (k, v) => new KeyValuePair<K, V>(k, v))
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        else
        {
            Dictionary<K, V> dict = new Dictionary<K,V>();
            HashSet<K> keySet = new HashSet<K>();
            for (int i = 0; i < keys.Length; i++)
            {
                K key = keys[i];
                if (keySet.Add(key))
                    dict.Add(key, values[i]);
            }
            return dict;
        }
    }
