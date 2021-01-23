            HostFactory.Run(x =>
                {
                    x.Service<MyServiceHost>(s =>
                        {
                            s.ConstructUsing(name => new MyServiceHost());
                            s.WhenStarted(tc => tc.Start());
                            s.WhenStopped(tc => tc.Stop());
                        });
                    x.DependsOnEventLog(); // Windows Event Log
                    x.DependsOnIis(); // Internet Information Server
                    x.StartAutomaticallyDelayed();
                    x.EnablePauseAndContinue();
                    x.EnableShutdown();
                    x.EnableServiceRecovery(rc =>
                        {
                            rc.RestartService(1); // restart the service after 1 minute
                            rc.SetResetPeriod(1); // set the reset interval to one day
                        });
                    x.RunAsLocalSystem();
                    x.SetDescription("The My Service provides services to the My Webspace web application that require elevated privileges, such as creating customer websites in IIS.");
                    x.SetDisplayName("My Service");
                    x.SetServiceName("MyService");
                });
