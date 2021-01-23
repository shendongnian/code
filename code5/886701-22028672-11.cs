    static void Main(string[] args)
    {
        for (var i = 0; i < 100; i++)
        {
            Task.Factory.StartNew(() => SomeMethod(), 
                TaskCreationOptions.LongRunning);
        }
        Console.ReadLine();
    }
