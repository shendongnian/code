    void Main()
    {
        Task t1 = Accept();
        t1.Wait();
        Console.WriteLine("Main ended");
    }
    
    public static async Task Accept()
    {
        while (true)
        {
            await Task.Delay(1000);
        }
    
        Console.WriteLine("Stoppped");
    }
