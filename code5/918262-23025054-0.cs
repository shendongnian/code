    class ProgramService : ServiceBase
    {
        IStartableBus bus;
        static void Main()
        {
            using (var service = new ProgramService())
            {
                // so we can run interactive from Visual Studio or as a service
                if (Environment.UserInteractive)
                {
                    service.OnStart(null);
                    Console.WriteLine("\r\nPress any key to stop program\r\n");
                    Console.Read();
                    service.OnStop();
                }
                else
                {
                    Run(service);
                }
            }
        }
        protected override void OnStart(string[] args)
        {
            Configure.GetEndpointNameAction = () => "SelfHostSample";
            bus = Configure.With()
                .DefaultBuilder()
                .UnicastBus()
                .CreateBus();
            bus.Start(Startup);
        }
        static void Startup()
        {
            //Only create queues when a user is debugging
            if (Environment.UserInteractive && Debugger.IsAttached)
            {
                Configure.Instance.ForInstallationOn<Windows>().Install();
            }
        }
        protected override void OnStop()
        {
            if (bus != null)
            {
                bus.Shutdown();
            }
        }
    }
