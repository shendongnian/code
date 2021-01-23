    var task1 = Task.Factory.StartNew(new Func<Task>(() =>
    {
        for (var i = 0; ; i++)
        {
            Thread.Sleep(i); // simulate work item #i
            token.ThrowIfCancellationRequested();
        }
    })).Unwrap();
