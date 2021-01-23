               protected override void ConfigureContainer()
               {
                   base.ConfigureContainer();
                    IApplicationDataServices applicationData = new ApplicationDataServices();
                    applicationData.Initialize();
                    Container.RegisterInstance(typeof(IApplicationDataServices), "ApplicationDataService", applicationData);
                }
