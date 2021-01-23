    public static class DictionaryExtensions
    {
        public static U GetValueOrDefault<T,U>(this IDictionary<T, U> dict, T key)
        {
            if(dict.ContainsKey(key))
            {
                return dict[key];
            }
            return default(U);
        }
    }
