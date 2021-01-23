    var queue = new BlockingCollection<string>();
    int workers = 5;
    CancellationTokenSource cts = new CancellationTokenSource();
    var tasks = new List<Task>();
    for (int i = 0; i < workers; i++)
    {
        tasks.Add(Task.Run(() =>
        {
            foreach (var item in queue.GetConsumingEnumerable())
            {
                cts.Token.ThrowIfCancellationRequested();
                DoWork(item);
            }
        }, cts.Token));
    }
    //throw this into a new task if adding the items will take too long
    foreach (var item in data)
        queue.Add(item);
    queue.CompleteAdding();
    Task.WhenAll(tasks).ContinueWith(t =>
    {
        //do completion stuff
    });
