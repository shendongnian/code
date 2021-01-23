    public class RepeatList<T> : IList<T>
    {
      private readonly IList<T> _backing;
      private readonly int _repeats;
      public RepeatList(IList<T> backing, int repeats)
      {
        if(backing == null)
          throw new ArgumentNullException("backing");
        if(repeats < 1)
          throw new ArgumentOutOfRangeException("repeats");
        _backing = backing;
        _repeats = repeats;
      }
      public RepeatList(int repeats)
        : this(new List<T>(), repeats)
      {
      }
      public T this[int index]
      {
        get { return _backing[index / _repeats]; }
        set { _backing[index / _repeats] = value; }
      }
      public int Count
      {
        get { return _backing.Count * _repeats; }
      }
      public bool IsReadOnly
      {
        get { return _backing.IsReadOnly; }
      }
      public int IndexOf(T item)
      {
        int idx = _backing.IndexOf(item);
        return idx >= 0 ? idx * _repeats : -1;
      }
      public void Insert(int index, T item)
      {
        _backing.Insert(index / _repeats, item);
      }
      public void RemoveAt(int index)
      {
        _backing.RemoveAt(index / _repeats);
      }
      public void Add(T item)
      {
        _backing.Add(item);
      }
      public void Clear()
      {
        _backing.Clear();
      }
      public bool Contains(T item)
      {
        return _backing.Contains(item);
      }
      public void CopyTo(T[] array, int arrayIndex)
      {
        if(array == null)
          throw new ArgumentNullException("array");
        if(arrayIndex < 0)
          throw new ArgumentOutOfRangeException("arrayIndex");
        if(array.Length - arrayIndex < _backing.Count * _repeats)
          throw new ArgumentException("array is too small to copy all elements starting from index " + arrayIndex);
        foreach(T item in this)
          array[arrayIndex++] = item;
      }
      public bool Remove(T item)
      {
        return _backing.Remove(item);
      }
      public IEnumerator<T> GetEnumerator()
      {
        foreach(T item in _backing)
          for(int i = 0; i != _repeats; ++i)
            yield return item;
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
    }
