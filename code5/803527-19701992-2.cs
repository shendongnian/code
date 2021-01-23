    public static class SharedCacheManager
    {
        public static bool TryGetValue<T>(string key, out T result)
        {
            var cache = HttpContext.Current.Cache;
            object o = cache[key];
            if (o == null)
            {
                result = default(T);
                return false;
            }
            else if (o.GetType() != typeof(T))
            {
                result = default(T);
                return false;
            }
            result = (T)o;
            return true;
        }
        public static void SetValue<T>(string key, T val)
        {
            var cache = HttpContext.Current.Cache;
            cache[key] = val;
        }
    }
