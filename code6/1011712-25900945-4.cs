    public static void Main() {
        HostFactory.Run(x => {
            x.Service<FooBar>( s => { 
                s.ConstructUsing(name => new FooBar());
                s.WhenStarted(fb => fb.Start());
                s.WhenStopped(fb => fb.Stop());
            });
            x.RunAsLocalSystem(); // use the local system account to run as
            x.SetDescription("My Foobar Service");  // description seen in services control panel
            x.SetDisplayName("FooBar"); // friendly name seen in control panell
            x.SetServiceName("foobar"); // used with things like net stop and net start
        });
    }
