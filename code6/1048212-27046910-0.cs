    class MyClass
    {
      private readonly AsyncManualResetEvent _mre = new AsyncManualResetEvent();
      public void TheMethodToAwait()
      {
        _mre.Set();
      }
      public Task TheMethodToAwaitWasExecutedAsync()
      {
        return _mre.WaitAsync();
      }
      // TODO: some code that calls _mre.Reset()
    }
