    public async Task Method1()
    {
        var temp = one;
        Console.WriteLine(temp);
        await Task.Delay(50);
        Console.WriteLine(temp);
    }
