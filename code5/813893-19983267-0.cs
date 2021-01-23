    private int _a1;
    public int A1
    {
      get
      {
        return _a1;
      }
      set
      {
        _a1 = value;
      }
    }
    
    public void Foo()
    {
      Bar(ref _a1);
    }
