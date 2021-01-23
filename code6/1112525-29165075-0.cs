    private static void Main(string[] args)
    {
        var scheduler = new ConcurrentExclusiveSchedulerPair(TaskScheduler.Default, 5)
            .ConcurrentScheduler;
        TaskFactory factory = new TaskFactory(scheduler);
        for (int i = 0; i < 10; ++i)
        {
            factory.StartNew(() => DoWork());
        }
        Console.ReadKey();
    }
    private static int StaticIntValueWorkOne, StaticIntValueWorkTwo;
    private static async Task DoWork()
    {
        // Do some stuff here like
        Console.WriteLine(DateTime.UtcNow + " StaticIntValueWorkOne" + Interlocked.Increment(ref StaticIntValueWorkOne));
        // And then more stuff that is async here
        await Task.Yield();
        Thread.Sleep(10000);
        Console.WriteLine(DateTime.UtcNow + " StaticIntValueWorkTwo" + Interlocked.Increment(ref StaticIntValueWorkTwo));
    }
