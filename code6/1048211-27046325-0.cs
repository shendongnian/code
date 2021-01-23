    class MyClass
    {
      private readonly TaskCompletionSource<object> _tcs = new TaskCompletionSource<object>();
      public void TheMethodToAwait()
      {
        _tcs.TrySetResult(null);
      }
      public Task TheMethodToAwaitWasExecutedAsync()
      {
        return _tcs.Task;
      }
    }
