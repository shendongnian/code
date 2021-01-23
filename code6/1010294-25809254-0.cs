    public static class Extensions
    {
        public static bool Push<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            try
            {
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key] = value;
                }
                else
                {
                    dictionary.Add(key, value);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static TValue Pull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            try
            {
                return dictionary.ContainsKey(key) ? dictionary[key] : default(TValue);
            }
            catch (Exception ex)
            {
                return default(TValue);
            }
        }
    }
