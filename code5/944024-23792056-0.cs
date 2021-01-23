    HostFactory.Run(x =>                                 //1
        {
            x.Service<TownCrier>(s =>                        //2
            {
               s.ConstructUsing(name=> new TownCrier());     //3
               s.WhenStarted(tc => tc.Start());              //4
               s.WhenStopped(tc => tc.Stop());               //5
            });
            x.RunAsLocalSystem();                            //6
            x.SetDescription("Sample Topshelf Host");        //7
            x.SetDisplayName("Stuff");                       //8
            x.SetServiceName("stuff");                       //9
        });    
