    Task t1 = factory.StartNew(() =>
    {
        DoSomething();
    }).ContinueWith((t2) =>
    {
        if (t2.IsCanceled)
            DoSomethingWhenCancelled();
        else if (t2.IsFaulted)
            DoSomethingOnError(t1.Exception);
        else
            DoSomethingWhenComplete();
    });
