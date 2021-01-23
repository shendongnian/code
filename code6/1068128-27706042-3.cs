    static void Main (string[] args)
    {
        // Configure ServiceStack Client
        IosPclExportClient.Configure();
    
        // Set AppDelegate
        UIApplication.Main (args, null, "AppDelegate");
    }
