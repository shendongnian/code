        public static T Read<T>(this Hashtable hash, string key)
        {
            if (!hash.ContainsKey(key))
                return default;
            if (hash[key] is T)
                return (T)hash[key];
            if (hash[key] is JToken token)
                return token.ToObject<T>();
            try
            {
                return (T)Convert.ChangeType(hash[key], typeof(T));
            }
            catch (InvalidCastException)
            {
                Debug.LogWarning($"{key} had the wrong type of {hash[key].GetType()}");
                return default;
            }
        }
