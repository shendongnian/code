        static class Program
        {
    #if DEBUG
            static AutoResetEvent sare = new AutoResetEvent(false);
    #endif
           
            static void Main()
            {
    #if (!DEBUG)           
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new Service() };
                ServiceBase.Run(ServicesToRun);
    #else
                Service service = new Service();
                service.DebugServiceStopped += new Action(SetAutoResetEvent);
    
                service.DebugStart();
    
                sare.WaitOne();
    #endif
            }
    
    #if DEBUG
            private static void SetAutoResetEvent()
            {
                sare.Set();
            }
    #endif        
        }
