    using System;
    using System.Diagnostics;
    using System.ServiceProcess;
 
    namespace WindowsService
    {
        static class Program
        {
            static void Main()
            {
                try
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] 
                    { 
                        new Service1() 
                    };
                    ServiceBase.Run(ServicesToRun);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
                }
            }
        }
    }
