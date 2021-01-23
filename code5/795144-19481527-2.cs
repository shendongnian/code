    static void Main()
    {
        MyConfig.BuildMyConfig("...", "...", HandleEmail);
    
        var monitoring = new Monitoring();
        monitoring.StartMonitoring();
    }
    
    static void HandleEmail(string thecontents)
    {
        // Sample implementation
        Console.WriteLine("Received Email: {0}",thecontents);
    }
