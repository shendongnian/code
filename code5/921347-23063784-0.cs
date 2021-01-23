    public static Task<OperationResult> OperationTaskAsync(this WCFService client)
    {
      var tcs = new TaskCompletionSource<OperationResult>();
      OperationCompletedEventHandler handler = null;
      handler = (_, e) =>
      {
        client.OperationCompleted -= handler;
        if (e.Error != null)
          tcs.TrySetException(e.Error);
        else if (e.Cancelled)
          tcs.TrySetCanceled();
        else
          tcs.TrySetResult(e.Result);
      };
      client.OperationCompleted += handler;
      client.OperationAsync();
      return tcs.Task;
    }
