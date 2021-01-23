    static void Main()
    {
        Console.WriteLine("start");
        Task task = Task.Factory.StartNew(PrintTime, CancellationToken.None);
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("master thread i={0}", i + 1);
            Thread.Sleep(1000);
        }
        try
        {
            task.Wait();
        }
        catch (AggregateException ae) 
        {
            ae.Handle((x) =>
            {
                 Console.WriteLine("Exception: " + x.ToString());
            });
        }
    }
