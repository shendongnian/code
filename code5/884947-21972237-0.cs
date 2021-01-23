    CountdownEvent cde = new CountdownEvent(3);
    object valueLock = new Object();
    static void Main(string[] args)
    {
        new Thread(Waiter).Start();
        new Thread(Waiter).Start();
        new Thread(Waiter).Start();
        for (; ; )
        {
            cde.Wait();
            Console.WriteLine("new round");
            cde.Reset(3);
            Monitor.PulseAll(valueLock);
        }
    }
    static void Waiter()
    {
        for (; ; )
        {
            Monitor.Wait(valueLock);
            Thread.Sleep(1000);
            Console.WriteLine("Waiter run");
            cde.Signal();
        }
    }
