    public object Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return this.result;
      }
    }
