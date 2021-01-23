    public Task(string von, string was, string an, DateTime zeit)
    {
     ...
    }
    
    public Task(string von, string was, string an) : this(von, was, an, DateTime.Now)
    {
      ...
    }
