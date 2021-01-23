    class Program
    {
        static void Main(string[] args)
        {
            Cache<string, string> stringCache = new Cache<string, string>();
            stringCache.Set("A String Index", "A String Item");
            if (stringCache.Exists("A String Index"))
                Console.WriteLine("Title Case exists");
            if (stringCache.Exists("A STRING INDEX"))
                Console.WriteLine("All Caps Exists");
            if (stringCache.Exists("a string index"))
                Console.WriteLine("All Lowercase Exists");
        }
    }
    class Cache<TIndex, TItem>
    {
        private IDictionary<TIndex, TItem> _cache { get; set; }
        public Cache()
        {
            if (typeof(TIndex) == typeof(string))
            {
                _cache = new Dictionary<TIndex, TItem>((IEqualityComparer<TIndex>)StringComparer.InvariantCultureIgnoreCase);
            }
            else
            {
                _cache = new Dictionary<TIndex, TItem>();
            }
        }
        public void Set(TIndex index, TItem item)
        {
            _cache[index] = item;
        }
        public bool Exists(TIndex index)
        {
            if (!_cache.ContainsKey(index))
            {
                return false;
            }
            return true;
        }
    }
