    public static void Main()
    {
        var queue = new ConcurrentQueue<int>();
        
        var stopwatch = new Stopwatch();
        
        queue.Pace(TimeSpan.FromSeconds(1))
            .Subscribe(
                x => Console.WriteLine(stopwatch.ElapsedMilliseconds + ": x" + x),
                e => Console.WriteLine(e.Message),
                () => Console.WriteLine("Done"));
            
        stopwatch.Start();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Thread.Sleep(500);
        queue.Enqueue(3);
        Thread.Sleep(5000);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);
        
        Console.ReadLine();
        
    }
