    static Task Test()
    {
        var random = new Random(Environment.TickCount).Next();
        if (random % 2 != 0)
            throw new ApplicationException("1st");
        return TestAsync();
    }
    static async Task TestAsync()
    {
        await Task.Delay(2000);
        Console.WriteLine("after await Task.Delay");
        throw new ApplicationException("2nd");
    }
    static void Main(string[] args)
    {
        try
        {
            Test();
            Console.WriteLine("TestAsync continues asynchronously...");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.ToString());
        }
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
