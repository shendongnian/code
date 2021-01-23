    static void Main()
            {
    #if (!DEBUG)
                System.ServiceProcess.ServiceBase[] ServicesToRun;
                ServicesToRun = new System.ServiceProcess.ServiceBase[] { new MyService() };
                System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    #else
                MyService service= new MyService();
                service.OnStart(null);    
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
    #endif 
           }
