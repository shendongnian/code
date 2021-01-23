    public static class DictionaryExtensions
    {
        public static T MergeLeft<T, K, V>(this T me, params IDictionary<K, V>[] others)
            where T : IDictionary<K, V>, new()
        {
            var newMap = new T();
            foreach (var p in (new List<IDictionary<K, V>> { me }).Concat(others).SelectMany(src => src))
            {
                newMap[p.Key] = p.Value;
            }
            return newMap;
        }
    }
