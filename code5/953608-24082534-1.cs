    [WebMethod]
    public IAsyncResult BeginFoo(int arg, AsyncCallback callback, object state)
    {
      return AsyncFactory<string>.ToBegin(FooAsync(arg), callback, state);
    }
    [WebMethod]
    public string EndFoo(IAsyncResult result)
    {
      return AsyncFactory<string>.ToEnd(result);
    }
