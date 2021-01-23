    public DateTime CreationTime
    {
      get
      {
        return this.CreationTimeUtc.ToLocalTime();
      }
      set
      {
        this.CreationTimeUtc = value.ToUniversalTime();
      }
    }
