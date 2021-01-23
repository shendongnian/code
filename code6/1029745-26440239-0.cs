    public abstract class MyDelegatingHandler
    {
      private readonly MyDelegatingHandler _next;
      public MyDelegatingHandler(MyDelegatingHandler next = null)
      {
        _next = next;
      }
      public virtual Task SendAsync()
      {
        if (_next == null)
          return Task.FromResult(0);
        return _next.SendAsync();
      }
    }
