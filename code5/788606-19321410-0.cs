    CancellationTokenSource cts = new CancellationTokenSource(25000);
    Task workChain = Task.Factory.StartNew((o) =>
    {
        Console.WriteLine("Running task {0} with state {1}", Task.CurrentId, o);
        Thread.Sleep(1000);
    }, -1);
    Task parent = workChain;
    for (int i = 0; i < 10; i++)
    {
        parent = parent.ContinueWith((ante, o) =>
            {
                Console.WriteLine("Running task {0} with state {1}", Task.CurrentId, o);
                Task subTask = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(10000);
                    Console.WriteLine("Subtask completed");
                });
                subTask.Wait(cts.Token);
            }, i, TaskContinuationOptions.OnlyOnRanToCompletion);
        parent.ContinueWith((ante) =>
            {
                foreach (Exception e in ante.Exception.InnerExceptions)
                {
                    if (e is OperationCanceledException)
                    {
                        //report timeout
                        Console.WriteLine("Timed out while running task id {0}", ante.Id);
                        return;
                    }
                }
                //report other exception
                Console.WriteLine("Something bad happened: {0}", ante.Exception.GetBaseException());
            }, TaskContinuationOptions.OnlyOnFaulted);
    }
    Task lastTask = parent.ContinueWith((ante) =>
        {
            //report success
            Console.WriteLine("Success");
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
