    public sealed class PersistentCache<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly PersistentDictionary<TKey, TValue> _backingInstance;
    
        public PersistentCache(PersistentDictionary<TKey, TValue> backingInstance)
        {
            _backingInstance = backingInstance;    
        }
        // implement IDictionary<TKey, TValue>
    }
