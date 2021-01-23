    static void Main()
    {
        Console.WriteLine("start");
        var mainThread = new Thread(MainThread);
        mainThread.Start();
        var task = Task.Factory
                       .StartNew(PrintTime)
                       .ContinueWith(t => { Console.WriteLine("Inner thread caused exception. Main thread is being aborted."); mainThread.Abort(); },
                                     TaskContinuationOptions.OnlyOnFaulted);
        task.Wait();
        Console.WriteLine("Waiting for main thread to abort...");
        mainThread.Join();
        Console.WriteLine("Main thread aborted.");
        Console.ReadLine();
    }
    private static void MainThread()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("master thread i={0}", i + 1);
            Thread.Sleep(1000);
        }
    }
    private static void PrintTime()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("inner thread i={0}", i + 1);
            Thread.Sleep(1000);
        }
        throw new Exception("exception");
    }
