    public static class DictionarySetExtensions
    {
      public static IDictionary<TKey, TValue> ExceptByKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> other)
      {
        return new ExceptDictionary<TKey, TValue>(dictionary, other);
      }
      private class ExceptDictionary<TKey, TValue> : IDictionary<TKey, TValue>
      {
        private readonly IDictionary<TKey, TValue> _source;
        private readonly IDictionary<TKey, TValue> _exclude;
        public ExceptDictionary(IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> exclude)
        {
          _source = source;
          _exclude = exclude;
        }
        public TValue this[TKey key]
        {
          get
          {
            if(_exclude.ContainsKey(key))
              throw new KeyNotFoundException();
            return _source[key];
          }
          //A non-readonly version is possible, but probably ill-advised. This sort of
          //approach creates surprises if you don't use immutable results.
          set { throw new InvalidOperationException("Read Only Dictionary"); }
        }
        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
          get
          {
            //there are more efficient approaches by creating a wrapper
            //class on this again, but this shows the principle.
            return this.Select(kvp => kvp.Key).ToList();
          }
        }
        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
          get
          {
            return this.Select(kvp => kvp.Value).ToList();
          }
        }
        //Note that Count is O(n), not O(1) as usual with collections.
        public int Count
        {
          get
          {
            int tally = 0;
            using(var en = GetEnumerator())
              while(en.MoveNext())
                ++tally;
            return tally;
          }
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
          get { return true; }
        }
        public bool ContainsKey(TKey key)
        {
          return _source.ContainsKey(key) && !_exclude.ContainsKey(key);
        }
        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
          throw new InvalidOperationException("Read only");
        }
        bool IDictionary<TKey, TValue>.Remove(TKey key)
        {
          throw new InvalidOperationException("Read only");
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
          if(_exclude.ContainsKey(key))
          {
            value = default(TValue);
            return false;
          }
          return _source.TryGetValue(key, out value);
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
          throw new InvalidOperationException("Read only");
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
          throw new InvalidOperationException("Read only");
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
          TValue cmp;
          return TryGetValue(item.Key, out cmp) && Equals(cmp, item.Value);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
          //Way lazy here for demonstration sake. This is the sort of use of ToList() I hate, but you'll get the idea.
          this.ToList().CopyTo(array, arrayIndex);
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
          throw new InvalidOperationException("Read only");
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
          foreach(var kvp in _source)
            if(!_exclude.ContainsKey(kvp.Key))
              yield return kvp;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
          return GetEnumerator();
        }
      }
    }
