    void static Main()
    {
        var xs = Observable.Range(0, 3);
        var ys = Observable.Range(10, 3);
        
        var source = ys.MergeWithLowPriorityStream(xs);
        
        source.Subscribe(Console.WriteLine, () => Console.WriteLine("Done"));
    }
