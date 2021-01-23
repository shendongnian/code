    async void MainMethod()
    {
        var sw = Stopwatch.StartNew();
        //Create Actions
        var actions = Enumerable.Range(0,200)
                                .Select( i=> ((Action)(()=>DoSomething(i))));
            
        //Run all parallel with 25 Tasks-in-parallel
        await DoAll(actions, 25);
        Console.WriteLine("Total Time: " + sw.ElapsedMilliseconds);
    }
    void DoSomething(int i)
    {
        Thread.Sleep(1000);
        Console.WriteLine(i + " completed");
    }
    async Task DoAll(IEnumerable<Action> actions, int maxTasks)
    {
        SemaphoreSlim semaphore = new SemaphoreSlim(maxTasks);
        foreach(var action in actions)
        {
            await semaphore.WaitAsync().ConfigureAwait(false);
            Task.Factory.StartNew(() =>action(), TaskCreationOptions.LongRunning)
                        .ContinueWith((task) => semaphore.Release());
        }
        for (int i = 0; i < maxTasks; i++)
            await semaphore.WaitAsync().ConfigureAwait(false);
    }
