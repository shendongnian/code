    static void Main(string[] args)
    {
        bool createdNew;
        Mutex mutex = new Mutex(true, "TestSO27835942", out createdNew);
        if (createdNew)
        {
            Console.WriteLine("First process!");
        }
        else
        {
            Console.WriteLine("Second process...waiting for first process");
            mutex.WaitOne();
            Console.WriteLine("First process has completed");
        }
        Console.WriteLine("Press return to exit...");
        Console.ReadLine();
        mutex.ReleaseMutex();
    }
