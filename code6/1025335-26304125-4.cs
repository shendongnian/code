    static void Main(string[] args)
    {
        var accountTask = Task.Run(async () => Console.WriteLine(await GetAccounts()));
        var depositsTask = Task.Run(async () => Console.WriteLine(await GetDeposits()));
        await Task.WhenAll(accountTask, depositsTask).Wait();
    }
