    private async Task InsertDB(RootObject obj)
    {
        Console.WriteLine(1);
        await Task.Run(() => obj.InsereDB());
        Console.WriteLine(2);
    }
    await InsertDB(obj);
    Console.WriteLine(3);
