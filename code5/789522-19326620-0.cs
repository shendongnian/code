    static Queue<int> queue1 = new Queue<int>();
    static BlockingCollection<int> queue2 = new BlockingCollection<int>();
    static void Main(string[] args)
    {
        Run(AddQueue1, ConsumeQueue1);
        Run(AddQueue2, ConsumeQueue2);
        Console.ReadLine();
    }
    private static void AddQueue1(int obj)
    {
        lock (queue1)
        {
            queue1.Enqueue(obj);
            if (queue1.Count == 1)
                Monitor.Pulse(queue1);
        }
    }
    private static void ConsumeQueue1()
    {
        lock (queue1)
        {
            while (true)
            {
                while (queue1.Count == 0)
                    Monitor.Wait(queue1);
                var item = queue1.Dequeue();
                // do something with item
            }
        }
    }
    private static void AddQueue2(int obj)
    {
        queue2.TryAdd(obj);
    }
    private static void ConsumeQueue2()
    {
        foreach (var item in queue2.GetConsumingEnumerable())
        {
            // do something with item
        }
    }
    private static void Run(Action<int> action, ThreadStart consumer)
    {
        new Thread(consumer) { IsBackground = true }.Start();
        Stopwatch stopwatch = Stopwatch.StartNew();
        Parallel.For(0, 100000000, new ParallelOptions() { MaxDegreeOfParallelism = 8 }, action);
        stopwatch.Stop();
        Console.WriteLine(action.Method.Name + " takes " + stopwatch.Elapsed);
    }
