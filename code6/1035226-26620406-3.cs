    public void Main()
    {
        AsyncExample();
        Console.WriteLine("prints first");
    }
    public async Task AsyncExample()
    {
        Task<string> executesSeparately = ExecutesSeparately();
        string result = await longRunningTask;
        Console.WriteLine(result);
    }
    public async Task<string> ExecutesSeparately()
    {
        await Task.Delay(2000);
        return "prints second";
    }
