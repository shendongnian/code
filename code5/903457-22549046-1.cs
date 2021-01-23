    void Compute(CancellationToken token, ParallelLoopState loopState)
    {
        bool more = true;
        while (more)
        {
            if (token.IsCancellationRequested)
            {
                // stop Parallel.ForEach ASAP
                loopState.Stop();
                return;
            }
            // do the calc step
        }
    }
    // ... 
    CancellationTokenSource cts = new CancellationTokenSource();
    ParallelOptions po = new ParallelOptions();
    po.CancellationToken = cts.Token;
    Task.Factory.StartNew(() =>
    {
        if (Console.ReadKey().KeyChar == 'c')
            cts.Cancel();
        Console.WriteLine("press any key to exit");
    });
    Parallel.ForEach(list, po, (algo, loopState) =>
    {
        algo.Compute(po.CancellationToken, loopState); // this compute lasts 1 minute  
        Console.WriteLine("this job is finished");
    });
    // observe the cancellation again and throw after Parallel.ForEach
    po.CancellationToken.ThrowIfCancellationRequested();
