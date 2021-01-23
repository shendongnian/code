    void Main()
    {
        var xs = Observable.Range(0, 10); // source events
        // "Double" here is our async operation to be constrained,
        // in this case to 3 concurrent invocations
        
        xs.Select(x =>
           Observable.Defer(() => Double(x).ToObservable())).Merge(3)
          .Subscribe(Console.WriteLine,
                     () => Console.WriteLine("Max: " + MaxConcurrent));
        
        
    }
    
    private static int Concurrent;
    private static int MaxConcurrent;
    private static readonly object gate = new Object();
    
    public async Task<int> Double(int x)
    {
        var concurrent = Interlocked.Increment(ref Concurrent);
        lock(gate)
        {
            MaxConcurrent = Math.Max(concurrent, MaxConcurrent);
        }
        
        await Task.Delay(TimeSpan.FromSeconds(1));
        
        Interlocked.Decrement(ref Concurrent);
        
        return x * 2;
    }
