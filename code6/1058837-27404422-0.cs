    public class SizeLimitedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int _maxSize;
        private readonly IDictionary<TKey, TValue> _dictionary;
        private readonly ReaderWriterLockSlim _readerWriterLock;
        public SizeLimitedDictionary(int maxSize)
        {
            _maxSize = maxSize;
            _dictionary = new Dictionary<TKey, TValue>(_maxSize);
            _readerWriterLock = new ReaderWriterLockSlim();
        }
        public bool TryAdd(TKey key, TValue value)
        {
            _readerWriterLock.EnterWriteLock();
            try
            {
                if (_dictionary.Count >= _maxSize)
                    return false;
                _dictionary.Add(key, value);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
            return true;
        }
        public void Add(TKey key, TValue value)
        {
            bool added = TryAdd(key, value);
            if(!added)
                throw new InvalidOperationException("Dictionary is at max size, can not add additional members.");
        }
        public bool TryAdd(KeyValuePair<TKey, TValue> item)
        {
            _readerWriterLock.EnterWriteLock();
            try
            {
                if (_dictionary.Count >= _maxSize)
                    return false;
                _dictionary.Add(item);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
            return true;
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            bool added = TryAdd(item);
            if (!added)
                throw new InvalidOperationException("Dictionary is at max size, can not add additional members.");
        }
        public void Clear()
        {
            _readerWriterLock.EnterWriteLock();
            try
            {
                _dictionary.Clear();
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
            
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            _readerWriterLock.ExitReadLock();
            try
            {
                return _dictionary.Contains(item);
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
            
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _readerWriterLock.ExitReadLock();
            try
            {
                _dictionary.CopyTo(array, arrayIndex);
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            _readerWriterLock.EnterWriteLock();
            try
            {
                return _dictionary.Remove(item);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }
        public int Count
        {
            get
            {
                _readerWriterLock.EnterReadLock();
                try
                {
                    return _dictionary.Count;
                }
                finally
                {
                    _readerWriterLock.ExitReadLock();
                }
            }
        }
        public bool IsReadOnly
        {
            get
            {
                _readerWriterLock.EnterReadLock();
                try
                {
                    return _dictionary.IsReadOnly;
                }
                finally
                {
                    _readerWriterLock.ExitReadLock();
                }
            }
        }
        public bool ContainsKey(TKey key)
        {
            _readerWriterLock.EnterReadLock();
            try
            {
                return _dictionary.ContainsKey(key);
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
        }
        public bool Remove(TKey key)
        {
            _readerWriterLock.EnterWriteLock();
            try
            {
                return _dictionary.Remove(key);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            _readerWriterLock.EnterReadLock();
            try
            {
                return _dictionary.TryGetValue(key, out value);
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
        }
        public TValue this[TKey key]
        {
            get
            {
                _readerWriterLock.EnterReadLock();
                try
                {
                    return _dictionary[key];
                }
                finally
                {
                    _readerWriterLock.ExitReadLock();
                }
            }
            set
            {
                _readerWriterLock.EnterUpgradeableReadLock();
                try
                {
                    var containsKey = _dictionary.ContainsKey(key);
                    _readerWriterLock.EnterWriteLock();
                    try
                    {
                        if (containsKey)
                        {
                            _dictionary[key] = value;
                        }
                        else
                        {
                            var added = TryAdd(key, value);
                            if(!added)
                                throw new InvalidOperationException("Dictionary is at max size, can not add additional members.");
                        }
                    }
                    finally
                    {
                        _readerWriterLock.ExitWriteLock();
                    }
                }
                finally
                {
                    _readerWriterLock.ExitUpgradeableReadLock();
                }
            }
        }
        public ICollection<TKey> Keys
        {
            get
            {
                _readerWriterLock.EnterReadLock();
                try
                {
                    return _dictionary.Keys;
                }
                finally
                {
                    _readerWriterLock.ExitReadLock();
                }
            }
        }
        public ICollection<TValue> Values
        {
            get
            {
                _readerWriterLock.EnterReadLock();
                try
                {
                    return _dictionary.Values;
                }
                finally
                {
                    _readerWriterLock.ExitReadLock();
                }
            }
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_dictionary).GetEnumerator();
        }
    }
