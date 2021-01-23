    internal class Cached<T> where T: class
    {
        private readonly Func<T> _loadFunc;
        private readonly string _key;
        private readonly TimeSpan _expiration;
        public Cached(Func<T> loadFunc, string key, TimeSpan expiration)
        {
            _loadFunc = loadFunc;
            _key = key;
            _expiration = expiration;
        }
        public T GetValue(bool reload)
        {
            T value = (T)HttpContext.Current.Cache[_key];
            if (reload || value == null)
            {
                value = _loadFunc();
                HttpContext.Current.Cache.Insert(_key, value, null,
                    DateTime.Now + _expiration, TimeSpan.Zero);
            }
            return value;
        }
    }
