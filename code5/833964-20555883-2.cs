    public sealed class MyHttpResult
    {
      public HttpResponse Result { get; private set; }
      public Exception Error { get; private set; }
      public bool WasCancelled { get; private set; }
    
      public MyHttpResult(HttpResponse result, Exception error, bool wasCancelled)
      {
        this.Result = result;
        this.Error = error;
        this.WasCancelled = wasCancelled;
      }
    }
