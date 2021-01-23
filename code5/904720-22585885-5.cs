    static async Task CoreLoopAsync(CancellationToken token)
    {
        using(var service1 = CreateWcfClientProxy())
        using(var service2 = CreateWcfClientProxy())
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
                var result = await CallBothServicesAsync("data");
                Console.WriteLine("Result: " + result);
            }
        }
    }
    
    static void Main()
    {
        var cts = CancellationTokenSource(10000); // cancel in 10s
        try
        {
            // block at the "root" level, i.e. inside Main
            CoreLoopAsync(cts.Token).Wait();
        }
        catch (Exception ex)
        {
            while (ex is AggregatedException)
                ex = ex.InnerException;
            // report the error
            Console.WriteLine(ex.Message);
        }
    }
