            if (Environment.UserInteractive)
            {
                log.Info("Starting as a console...");
                // call my service runner 
            }
            else{
                  log.Info("Starting as a service...");
                log.Info(this.ServiceDisplayName);
                log.Info(this.ServiceDescription);
                ServiceBase[] servicesToRun = new ServiceBase[] 
                { 
                    new MyServiceImpl();
                };
                try
                {
                    ServiceBase.Run(servicesToRun);
                }
                catch (Exception e)
                {
                    log.Fatal("A fatal error occurred while running.", e);
                    throw;
                }
             }
