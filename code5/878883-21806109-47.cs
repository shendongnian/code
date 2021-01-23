    static async Task DoSomethingAsync2(int id)
    {
        await Task.Factory.StartNew(() =>
        {
            Thread.Sleep(50);
            UpdateMaxThreads();
            Console.WriteLine(@"DidSomethingAsync2({0})", id);
        }, TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
    }
    // ...
    static void Main()
    {
        Console.WriteLine("Press enter to test with Task.Delay ...");
        Console.ReadLine();
        TestAsync(DoSomethingAsync);
        Console.ReadLine();
    
        Console.WriteLine("Press enter to test with Thread.Sleep ...");
        Console.ReadLine();
        TestAsync(DoSomethingAsync2);
        Console.ReadLine();
    }
