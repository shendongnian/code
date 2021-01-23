    static void Main(string[] args)
    {
        Console.WriteLine("HELLO WORLD");
        var t1 = Task.Factory.StartNew(new Func<Task>(async () => await Method()))
            .Unwrap();
        Console.WriteLine("STARTED");
        t1.Wait();
        Console.WriteLine("COMPLETED");
        Console.ReadKey();
    }
    static async Task Method()
    {
        // this method is perfectly safe to use async / await keywords
        Console.WriteLine("BEFORE DELAY");
        await Task.Delay(1000);
        Console.WriteLine("AFTER DELAY");
    }
