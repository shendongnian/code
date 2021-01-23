    AutoResetEvent flag = new AutoResetEvent(false);
    new Thread(() =>
    {
        Thread.CurrentThread.Priority = ThreadPriority.Lowest;
        Console.WriteLine("Work Item Started");
        flag.WaitOne();
        Console.WriteLine("Work Item Executed");
    }).Start();
    // For fast systems, you can help by occupying processors.
    //for (int ix = 0; ix < 10; ++ix)
    //{
    //    new Thread(() => { while (true) ; }).Start();
    //}
    Thread.Sleep(1000);
    flag.Set();
    // Decomment here to make it work
    //Thread.Sleep(1000);
    flag.Reset();
    Console.WriteLine("Finished");
    Console.ReadLine();
