    using (var thread = new AsyncContextThread())
    {
      Task t = thread.TaskFactory.Run(async () =>
      {
        while (true)
        {
          cts.Token.ThrowIfCancellationRequested();
          try
          {
            "Running...".Dump();
            await Task.Delay(500, cts.Token);
          }
          catch (TaskCanceledException ex) { }
        }
      });
    }
