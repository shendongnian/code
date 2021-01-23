    public static class MyExtensions
    {
        public static TValue ObjectForKey<TKey,TValue>(this Dictionary<TKey,TValue> dictionary, TKey key)
        {
            TValue val = default(TValue);
            dictionary.TryGetValue(key,out val);
            return val;
        }
    }   
