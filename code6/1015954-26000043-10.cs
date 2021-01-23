    static async Task Test()
    {           
        Console.WriteLine("Done");
        Console.WriteLine(await foo());
        Console.WriteLine(await Delay1());
    }
    static void Main(string[] args)
    {           
        Test().Wait();
    }
