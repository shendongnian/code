    static void Main(string[] args)
    {
        // A cancellation source that will cancel itself after 1 second
        var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));
                    
        try
        {
            // This will only wait 1 second because as it will be cancelled.
            Task t = Delay(5000, cancellationTokenSource.Token);                
            t.Wait();
            Console.WriteLine("The task completed");
        }
        catch (AggregateException exception)
        {
            // Expecting a TaskCanceledException
            foreach (Exception ex in exception.InnerExceptions)
                Console.WriteLine("Exception: {0}", ex.Message);
        }
        Console.WriteLine("Done");
        Console.ReadLine();
    }
    
    private static Task Delay(int milliseconds, CancellationToken token)
    {
        var tcs = new TaskCompletionSource<object>();
        token.Register(() => tcs.TrySetCanceled());
        Timer timer = new Timer(_ => tcs.TrySetResult(null));
        timer.Change(milliseconds, -1);            
        return tcs.Task;
    }
