    public static class DictionaryExtensionMethods
    {
        public static bool ContentEquals<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> otherDictionary)
        {
            return otherDictionary.OrderBy(kvp => kvp.Key).SequenceEqual(dictionary.OrderBy(kvp => kvp.Key));
        }
    }
