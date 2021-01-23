		private static void Main(string[] args)
		{
			HostFactory.Run(x =>
			{
				x.Service<FooBar>(s =>
				{
					s.ConstructUsing(CreateService);
					s.WhenStarted(CallStart);
					s.WhenStopped(CallStop);
				});
                x.RunAsLocalSystem(); // use the local system account to run as
                x.SetDescription("My Foobar Service");  // description seen in services control panel
                x.SetDisplayName("FooBar"); // friendly name seen in control panell
                x.SetServiceName("foobar"); // used with things like net stop and net start
			});
		}
		private static void CallStop(FooBar fb)
		{
			fb.Stop();
		}
		private static void CallStart(FooBar fb)
		{
			fb.Start();
		}
		private static FooBar CreateService(HostSettings name)
		{
			return new FooBar();
		}
