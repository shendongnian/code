    // Core async method containing all logic.
    private Task<string> FooAsync(int arg);
    // Original (synchronous) method looked like this:
    // [WebMethod]
    // public string Foo(int arg);
    [WebMethod]
    public IAsyncResult BeginFoo(int arg, AsyncCallback callback, object state)
    {
      var tcs = new TaskCompletionSource<string>(state);
      var task = FooAsync(arg);
      task.ContinueWith(t =>
      {
        if (t.IsFaulted)
          tcs.TrySetException(t.Exception.InnerExceptions);
        else if (t.IsCanceled)
          tcs.TrySetCanceled();
        else
          tcs.TrySetResult(t.Result);
        if (callback != null)
          callback(tcs.Task);
      });
      return tcs.Task;
    }
    [WebMethod]
    public string EndFoo(IAsyncResult result)
    {
      return ((Task<string>)result).GetAwaiter().GetResult();
    }
