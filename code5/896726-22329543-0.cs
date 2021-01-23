    Debug.WriteLine("command execute on {0}", Thread.CurrentThread.ManagedThreadId);
    Task.Factory.StartNew(() =>
    {
       Debug.WriteLine("executing on {0}", Thread.CurrentThread.ManagedThreadId);
       Thread.Sleep(1000);
    })
      .ContinueWith(t =>
    {
      Debug.WriteLine("task finished on {0}", Thread.CurrentThread.ManagedThreadId);
    }, TaskScheduler.FromCurrentSynchronizationContext());
