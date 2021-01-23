    public static Task<TResult> Request<TRequest, TResult>(this IBus bus, TRequest request)
    {
      var tcs = new TaskCompletionSource<TResult>();
      var id = Guid.NewGuid();
      bus.Subscribe<TResult>(id, result =>
      {
        bus.Unsubscribe<TResult>(id);
        tcs.TrySetResult(result);
      });
      bus.Publish(request);
      return tcs.Task;
    }
