	public class MyApphost : AppHostHttpListenerBase
	{
		public MyApphost() : base("Service Name", typeof(MyApphost).Assembly) {}
		public override void Configure(Container container)
		{
			Plugins.Add(new AuthFeature(
				() => new AuthUserSession(),
				new IAuthProvider[] { new CustomCredentialsAuthProvider()}
			));
		}
	}
