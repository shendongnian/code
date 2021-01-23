    static void Main()
    {
    #if (!DEBUG)
        System.ServiceProcess.ServiceBase[] servicesToRun;
        servicesToRun = new System.ServiceProcess.ServiceBase[] { new MyService() };
        System.ServiceProcess.ServiceBase.Run(servicesToRun);
    #else
        MyService service= new MyService();
        service.OnStart(null);    
        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
    #endif 
    }
