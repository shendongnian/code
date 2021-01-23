    static void Main(string[] args)
    {
        System.Threading.ThreadPool.SetMaxThreads(200, 200);
        for (var i = 0; i < 100; i++)
        {
            Task.Factory.StartNew(() => SomeMethod(), 
                TaskCreationOptions.LongRunning);
        }
        Console.ReadLine();
    }
