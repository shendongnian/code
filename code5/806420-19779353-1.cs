    void Main()
    {
        CountExampleAsync().Wait();
    }
    
    private async Task CountExampleAsync()
    {
        int result = await StreamWith5Elements().Count();
        Console.WriteLine(result);
    }
