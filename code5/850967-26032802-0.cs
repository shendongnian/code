    public static void Main()
    {
        Awaitable()
            .ContinueWith(
                i =>
                    {
                        foreach (var exception in i.Exception.InnerExceptions)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    },
                TaskContinuationOptions.OnlyOnFaulted);
        Console.WriteLine("This needs to come out before my exception");
        Console.ReadLine();
    }
    public static async Task Awaitable()
    {
        await Task.Delay(3000);
        throw new Exception("Hey I can catch these pesky things");
    }
