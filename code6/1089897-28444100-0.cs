                var service = new MyService();
                if (Environment.UserInteractive)
                {
                    service.Start(args);
                    Console.WriteLine("Press any key to stop program");
                    Console.Read();
                    service.Stop();
                }
                else
                {
                    ServiceBase.Run(service);
                }
