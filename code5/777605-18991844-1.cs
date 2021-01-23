    bool runLoop = true;
    ManualResetEvent allDoneEvent = new ManualResetEvent(false);
    Console.CancelKeyPress += (s, e) =>
    {
        runLoop = false;
        allDoneEvent.WaitOne();
    };
    int i = 0;
    while (runLoop)
    {
        Console.WriteLine(i++);
        Thread.Sleep(1000);  //placeholder for real work
    }
    //for debugging purposes only
    Console.WriteLine();
    Console.WriteLine("press any key to exit . . .");
    Console.ReadKey(true);
    allDoneEvent.Set();
