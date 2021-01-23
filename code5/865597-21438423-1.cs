    public static class Ext
    {
       public static void Add<TKey, TValue>(this Dictionary<TKey, TValue> d, TKey key) where TValue : new()
        {
            d.Add(key, new TValue());
        }
    }
