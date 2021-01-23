    public void RefreshContext(string myConnectionString)
    {
      DisposeContext();
      Context = new MyContext(myConnectionString);
    }
    public void DisposeContext()
    {
      if (Context == null)
        return;
      Context.Dispose();
    }
