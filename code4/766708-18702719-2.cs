    try
    {
        var config = ZorgConfiguration.InitializeFrom(args);
        // you can use config.File1 etc
    }
    catch (ZorgConfigurationException e)
    {
        Console.WriteLine(e.Message);
        // exit application
    }
