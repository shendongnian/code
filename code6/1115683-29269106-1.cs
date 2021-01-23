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
    private static object gate = new Object();
    
    public async Task<int> Double(int x)
    {
        lock(gate)
        {
            Concurrent++;
            MaxConcurrent = Math.Max(MaxConcurrent, Concurrent);
        }
        
        await Task.Delay(TimeSpan.FromSeconds(1));
        
        lock(gate)
        {
            Concurrent--;
        }
        
        return x * 2;
    }
