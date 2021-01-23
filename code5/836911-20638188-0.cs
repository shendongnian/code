    private static void RunService()
    {
        var service = new YourService();
        System.ServiceProcess.ServiceBase.Run(service);
    }
    //for debug only
    private static void RunNoService()
    {
        using (var service = new YourService())
        {
            service.Start();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
