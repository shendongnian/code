        public static int Main()
        {
            var exitCode = HostFactory.Run
            (
                c =>
                {
                    c.Service<Service>
                    (
                        sc =>
                        {
                            sc.ConstructUsing(name => new Service());
                            sc.WhenStarted((service, hostControl) => service.Start(hostControl));
                            sc.WhenStopped((service, hostControl) => Service.Stop(hostControl));
                        }
                    );
                    c.SetServiceName("ServiceName");
                    
                    c.SetDisplayName("DisplayName");
                    
                    c.SetDescription("Description");
                    c.EnablePauseAndContinue();
                    
                    c.EnableShutdown();
                    c.StartAutomaticallyDelayed();
                    
                    c.RunAsLocalSystem();
                }
            );
            return (int)exitCode;
        }
