    /// <summary>
    /// Custom cache interface
    /// </summary>
    interface ICustomCache
    {
        bool IsFound(string key, out object value); //returns true if found the object
        void Set(string key, object value); //If there is already an object with such a key, then the set should replace the old object
    }
    /// <summary>
    /// In memory cache implementation
    /// </summary>
    public class CustomCache : ICustomCache
    {
        // use thread safe dictionary
        private readonly ConcurrentDictionary<string, object> _cacheDictionary = new ConcurrentDictionary<string, object>();
        public bool IsFound(string key, out object value)
        {
            if (_cacheDictionary.ContainsKey(key))
            {
                return _cacheDictionary.TryGetValue(key, out value);
            }
            value = null;
            return false;
        }
        public void Set(string key, object value)
        {
            if (_cacheDictionary.ContainsKey(key))
            {
                object dummy;
                if (_cacheDictionary.TryRemove(key, out dummy))
                {
                    _cacheDictionary.TryAdd(key, value);
                }
            }
            else
            {
                _cacheDictionary.TryAdd(key, value);
            }
        }
    }
    /// <summary>
    /// Cache manager
    /// </summary>
    public static class CacheManager
    {
        private static ICustomCache _cache = null;
        static CacheManager()
        {
            // alternatly use Ioc container like Unity to create the object
            _cache = new CustomCache();
        }
        public bool IsFound(string key, out object value)
        {
            return _cache.IsFound(key, out value);
        }
        public void Set(string key, object value)
        {
            _cache.Set(key, value);
        }
    }
    // usage
    CacheManager.Set("test1", "hello world!");
