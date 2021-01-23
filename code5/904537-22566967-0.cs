    public static class DictionaryExtensionMethods
    {
        public static T MostRelevantData<T>(this IDictionary<Key, T> dict, Key key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            Key relevantKey = dict.Keys.FirstOrDefault(
                loop => key.IsRelevant(loop));
            if (relevantKey != null)
            {
                return dict[relevantKey];
            }
            throw new KeyNotFoundException();
        }
    }
