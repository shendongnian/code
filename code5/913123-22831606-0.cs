    public static void Main()
    {
        // Very simple self hosted console host
        var appHost = new AppHost();
        appHost.Init();
        appHost.Start("http://*:8080/"); // Update the port number here, change 8080
        Console.ReadKey();
    }
