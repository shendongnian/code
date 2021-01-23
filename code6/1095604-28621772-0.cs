    public static async Task MainAsync()
    {
        string result = await GetStringAsync();    
        Console.WriteLine(result);
    }
    public static int Main(string[] args)
    {
        MainAsync().Wait();
    }
