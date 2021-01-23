    public int SomeProperty
    {
      get { return properties.Get( model => model.SomeProperty ); }
      set { properties.Set( model => model.SomeProperty, value ); }
    }
