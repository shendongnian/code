    class WebServiceStub : IWebService
    {
      public int RequiredConcurrentRequests = 2;
      private TaskCompletionSource<object> _signal = new TaskCompletionSource<object>();
      async Task<T> IWebService.ProcessBookingAsync(id, booking)
      {
        if (Interlocked.Decrement(ref RequiredConcurrentRequests) == 0)
          _signal.TrySetResult(null);
        await _signal.Task;
        return ...;
      }
    }
