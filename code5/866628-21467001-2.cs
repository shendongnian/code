    Task t1 = factory.StartNew(() =>
    {
        DoSomething();
    }).
    ContinueWith((t2) =>
    {
        if (t1.IsCanceled)
            DoSomethingWhenCancelled();
        else if (t1.IsFaulted)
            DoSomethingOnError(t1.Exception);
        else
            DoSomethingWhenComplete();
    }, TaskScheduler.FromCurrentSynchronizationContext());
