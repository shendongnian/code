    private async void InsertDB(RootObject obj)
    {
        Console.WriteLine(1);
        await Task.Run(() => obj.InsereDB());
        Console.WriteLine(2);
    }
    InsertDB(obj);
    Console.WriteLine(3);
