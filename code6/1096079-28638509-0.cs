    public class Cache
    {
        private const uint DefaultCacheSize = 100;
        private readonly Dictionary<string, object> _cache = new Dictionary<string, object>();
        private readonly object _cacheLocker = new object();
        private readonly uint _cacheSize;
        public Cache(uint cacheSize = DefaultCacheSize)
        {
            _cacheSize = cacheSize;
        }
        public uint CacheSize
        {
            get { return _cacheSize; }
        }
        public TValue Resolve<TObj, TValue>(TObj item, Func<TObj, TValue> func, [CallerMemberName] string key = "")
        {
    #if FULL_NAME
            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();
            key = string.Format("{0}_{1}",
                method.DeclaringType == null ? string.Empty : method.DeclaringType.FullName,
                method.Name);
    #endif
            return CacheResolver(item, func, key);
        }
        private TValue CacheResolver<TObj, TValue>(TObj item, Func<TObj, TValue> func, string key)
        {
            object res;
            if (_cache.TryGetValue(key, out res) && res is TValue)
            {
                return (TValue) res;
            }
            TValue result = func(item);
            lock (_cacheLocker)
            {
                _cache[key] = result;
                if (_cache.Keys.Count > DefaultCacheSize)
                {
                    _cache.Remove(_cache.Keys.First());
                }
            }
            return result;
        }
    }
