    public class ReverseEnumerator<T> : IEnumerator<T> {
    
      private IList<T> _list;
      private int _index;
      private T _current;
    
      public ReverseEnumerator(IList<T> list) {
        _list = list;
        Reset();
      }
    
      public IEnumerator<T> GetEnumerator() {
        return this;
      }
    
      public T Current {
        get {
          if (_index < 0 && _index >= _list.Count) throw new InvalidOperationException("Enumeration has not started. Call MoveNext.");
          return _current;
        }
      }
    
      public void Dispose() { }
    
      object IEnumerator.Current { get { return Current; } }
    
      public bool MoveNext() {
        bool ok = --_index >= 0;
        if (ok) _current = _list[_index];
        return ok;
      }
    
      public void Reset() {
        _index = _list.Count;
      }
    
    }
