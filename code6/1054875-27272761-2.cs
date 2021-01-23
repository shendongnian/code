    using System;
    using System.Collections.Generic;
    public static class DictionaryExtensions
    {
        public static T GetValue<T>(this Dictionary<string, object> dictionary, string key)
        {
            object value = null;
            if (!dictionary.TryGetValue(key, out value))
            {
                throw new KeyNotFoundException(key);
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
