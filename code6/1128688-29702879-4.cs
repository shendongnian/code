    private class CountToTenEnumerator : IEnumerator<int>
    {
      private int _current;
      public int Current
      {
        get
        {
          if(_current == 0)
            throw new InvalidOperationException();
          return _current;
        }
      }
      object IEnumerator.Current
      {
        get { return Current; }
      }
      public bool MoveNext()
      {
        if(_current == 10)
          return false;
        _current++;
        return true;
      }
      public void Reset()
      {
        throw new NotSupportedException();
        // We *could* just set _current back, but the object produced by
        // yield won't do that, so we'll match that.
      }
      public void Dispose()
      {
      }
    }
    private class CountToTenEnumerable : IEnumerable<int>
    {
      public IEnumerator<int> GetEnumerator()
      {
        return new CountToTenEnumerator();
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
    }
    public static IEnumerable<int> CountToTen()
    {
      return new CountToTenEnumerable();
    }
