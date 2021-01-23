    internal class  UnionDictionary<TKey, TValue> : ReadOnlyDictionaryBase<TKey, TValue>
    {
      private readonly IDictionary<TKey, TValue> _first;
      private readonly IDictionary<TKey, TValue> _second;
      public UnionDictionary(IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
      {
        _first = first;
        _second = second;
      }
      public override bool TryGetValue(TKey key, out TValue value)
      {
        return _first.TryGetValue(key, out value) || _second.TryGetValue(key, out value);
      }
      public override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
      {
        foreach(var kvp in _first)
          yield return kvp;
        foreach(var kvp in _second)
          if(!_first.ContainsKey(kvp.Key))
            yield return kvp;
      }
    }
