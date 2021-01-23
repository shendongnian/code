    public string Name 
    {
      get { return Property.Get(string.Empty); }
      set { Property.Set(value); }
    } 
    public string Greeting => Property.Calculated(() => "Hello, " + Name + "!");
