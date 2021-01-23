    private readonly object _tSync = new object();
    private T _t = null;
    public T Instance
    {
      get
      {
        if (_t == null)
        {
          lock(_tsync)
          {
            if (_t == null)  // Second check b/c another thread may've gotten the lock while we were waiting.
            {
              _t = new T();
            }
          }
        }
        return _t;
      }
    }
