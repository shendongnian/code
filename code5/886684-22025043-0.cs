    private T _t = null;
    public T Instance
    {
      get
      {
        if (_t == null) {_t = new T();}
        return _t;
      }
    }
