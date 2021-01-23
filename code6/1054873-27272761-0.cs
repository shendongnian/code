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
            object result = null;
            if (typeof(T) == typeof(decimal))
            {
                result = Convert.ToDecimal(value);
            }
            if (typeof(T) == typeof(short))
            {
                result = Convert.ToInt16(value);
            }
            if (typeof(T) == typeof(int))
            {
                result = Convert.ToInt32(value);
            }
            if (typeof(T) == typeof(string))
            {
                result = Convert.ToString(value);
            }
            return (T)(object)result;
        }
    }
