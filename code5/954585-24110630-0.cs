    public static async Task Test()
    {
        Task pending = Task.FromResult(true);
        try
        {
            pending = SendAsync1();
        }
        catch (Exception)
        {
            Console.WriteLine("1-sync");
        }
        try
        {
            await pending;
        }
        catch (Exception)
        {
            Console.WriteLine("1-async");
        }
        pending = Task.FromResult(true);
        try
        {
            pending = SendAsync2();
        }
        catch (Exception)
        {
            Console.WriteLine("2-sync");
        }
        try
        {
            await pending;
        }
        catch (Exception)
        {
            Console.WriteLine("2-async");
        }
    }
    public static async Task SendAsync1()
    {
        throw new Exception("Sync Exception");
        await Task.Delay(10);
    }
    public static Task SendAsync2()
    {
        throw new Exception("Sync Exception");
        return Task.Delay(10);
    }
