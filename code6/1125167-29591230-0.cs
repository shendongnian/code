    var timer = new System.Threading.Timer(async (e) =>
    {
        await Task.Delay(500);
        Console.WriteLine("Tick");
    }, null, 0, 5000);
