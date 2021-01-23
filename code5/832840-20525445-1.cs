    public static class DictionaryExtensions
    {
        public static TValue EnsureContainsAndGet<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key) where TValue : new()
        {
            TValue value;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = new TValue();
                dictionary.Add(key, value);
            }
            return value;
        }
    }
