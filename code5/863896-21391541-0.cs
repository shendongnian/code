    Lazy<IBar> b = new Lazy<IBar>();
    public IBar Bar
    {
      get
      {
        return b.Value;
      }
    }
