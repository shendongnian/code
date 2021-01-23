    public class ConcurrentDictionaryEx<TKey, TValue>
    {
        private readonly object _lock = new object();
        private ConcurrentDictionary<TKey, TValue> _dic;
        public int Capacity { get; set; }
        public int Count { get; set; }
        public ConcurrentDictionaryEx(int capacity, int concurrencyLevel = 2)
        {
            this.Capacity = capacity;
            _dic = new ConcurrentDictionary<TKey, TValue>(concurrencyLevel, capacity);
        }
        public bool TryAdd(TKey key, TValue value)
        {
            lock (_lock)
            {
                if (this.Count < this.Capacity && _dic.TryAdd(key, value))
                {
                    this.Count++;
                    return true;
                }
                return false;
            }
        }
        public bool TryRemove(TKey key, out TValue value)
        {
            lock (_lock)
            {
                if (_dic.TryRemove(key, out value))
                {
                    this.Count--;
                    return true;
                }
                return false;
            }
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            lock (_lock)
            {
                return _dic.TryGetValue(key, out value);
            }
        }
        public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
        {
            lock (_lock)
            {
                return _dic.TryUpdate(key, newValue, comparisonValue);
            }
        }
    }
