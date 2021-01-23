    void Main()
    {
        var source = Observable.Interval(TimeSpan.FromMilliseconds(10)).Take(100);
        
        source.Sample(TimeSpan.Zero, NewThreadScheduler.Default)
            .Subscribe(SlowConsumer);
                
        Console.ReadLine();
    }
    
    private void SlowConsumer(long item)
    {    
        Console.WriteLine(item + " " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(TimeSpan.FromSeconds(1));
    }
