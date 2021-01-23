    Task.Run(() =>
    {
        lock (a.B.C)
        {
            Console.WriteLine("a.B.C");
            Thread.Sleep(5000);
        }
    });
    Task.Run(() =>
    {
        lock (a.B)
        {
            Console.WriteLine("a.B");
            Thread.Sleep(5000);
        }
    });
    Task.Run(() =>
    {
        lock (a)
        {
            Console.WriteLine("a");
            Thread.Sleep(5000);
        }
    });
