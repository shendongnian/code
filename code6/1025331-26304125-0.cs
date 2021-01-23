    static async Task Test()
    {
        var accountTask = GetAccounts(); // GetAccounts executing
        var clientsTask = GetClients(); // Both executing
        
        Console.WriteLine(await accountTask); // Waiting for GetAccounts to complete. Both executing.
        Console.WriteLine(await clientsTask); // Waiting for GetClients to complete. GetClients executing
    }
