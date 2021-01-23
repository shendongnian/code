    void Main()
    {
        Task t1 = Task.Factory.StartNew(Accept);
        t1.Wait();
        Console.WriteLine("Main ended");
    }
    
    public static async void Accept()
    {
        while (true)
        {
            await Task.Delay(1000);
        }
    
        Console.WriteLine("Stoppped");
    }
