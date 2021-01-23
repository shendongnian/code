    static async Task DoAsync()
    {
        Console.WriteLine("Prepare");
        Console.WriteLine(await WorkAsync());
    }
    
