    var task = Task.Factory.StartNew(() =>
    {
        Debug.WriteLine("Current Context: {0}", TaskScheduler.Current);
    }, CancellationToken.None, TaskCreationOptions.DenyChildAttach,
        TaskScheduler.FromCurrentSynchronizationContext());
