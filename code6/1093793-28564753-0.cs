    Task child = null;
    var parent = Task.Factory.StartNew(() =>
    {
      child = Task.Factory.StartNew(() =>
      {
        while (!token.IsCancellationRequested) Thread.Sleep(100);
        token.ThrowIfCancellationRequested();
      }, token, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
      
      // This is the magic line.
      child.Wait(token);
    }, token);
