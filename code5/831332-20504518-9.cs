    internal abstract class ReadOnlyDictionaryBase<TKey, TValue> : IDictionary<TKey, TValue>
    {
      public TValue this[TKey key]
      {
        get
        {
          TValue value;
          if(!TryGetValue(key, out value))
            throw new KeyNotFoundException();
          return value;
        }
      }
      TValue IDictionary<TKey, TValue>.this[TKey key]
      {
        get { return this[key]; }
        set { throw new InvalidOperationException("Read only"); }
      }
      public ICollection<TKey> Keys
      {
        get { return this.Select(kvp => kvp.Key).ToList(); }
      }
      public ICollection<TValue> Values
      {
        get { return this.Select(kvp => kvp.Value).ToList(); }
      }
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
        TValue unused;
        return TryGetValue(key, out unused);
      }
      void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
      {
        throw new NotSupportedException("Read only");
      }
      bool IDictionary<TKey, TValue>.Remove(TKey key)
      {
        throw new NotSupportedException("Read only");
      }
      public abstract bool TryGetValue(TKey key, out TValue value);
      void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
      {
        throw new NotSupportedException("Read only");
      }
      void ICollection<KeyValuePair<TKey, TValue>>.Clear()
      {
        throw new NotSupportedException("Read only");
      }
      public bool Contains(KeyValuePair<TKey, TValue> item)
      {
        TValue value;
        return TryGetValue(item.Key, out value) && Equals(value, item);
      }
      public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
      {
        this.ToList().CopyTo(array, arrayIndex);
      }
      bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
      {
        throw new NotSupportedException("Read only");
      }
      public abstract IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
    }
