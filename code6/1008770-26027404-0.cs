    HostFactory.Run(x =>
           {
               x.SetDescription("Data Service - POC");
               x.SetDisplayName("Data Service");
               x.SetServiceName("DataService");
               x.EnablePauseAndContinue();
               x.Service<SampleService>(s =>
               {
                   s.ConstructUsing(() => new SampleService());                    
                   s.WhenStarted(v => v.Start());                   
                   s.WhenStopped(v => v.Stop());
                   s.WhenPaused(v => v.AnotherPause());
                   s.WhenContinued(v => v.Continue());
               });
               x.RunAsLocalSystem();
           });
