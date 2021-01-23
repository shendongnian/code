    public static async Task Test()
    {
        Console.WriteLine("This should be written first..");
        // These should be printed last..
        await Task.WhenAll(new[]
            {
                PrintNumber(1),
                PrintNumber(2),
                PrintNumber(3)
            });
    }
