    using (var cts = new CancellationTokenSource())
    {
      cts.CancelAfter(2000);
      SomethingThatMightThrow();
      try
      {
        await Task.Delay(10000, cts.Token);
      }
      catch (OperationCanceledException)
      {
        Callback();
      }
    }
