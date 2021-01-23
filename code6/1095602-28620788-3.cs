    public static int Main(string[] args)
    {
        string result;  
    
        Task.Run(async () =>
        {
            // We run on a thread pool thread
            Task<string> getStringTask = GetStringAsync();
            // We do get here because any thread pool thread can execute this code, we don't need the main thread.
            result = await validationsTask;
        }).Wait();
    
        Console.WriteLine(result);
    }
