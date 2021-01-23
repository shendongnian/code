	public class MyApphost : AppHostHttpListenerBase
	{
		public MyApphost() : base("Service Name", typeof(MyApphost).Assembly) {}
		public override void Configure(Container container)
		{
			// Register database connection before creating a provider...
			var conn = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["BlaBla"].ConnectionString, MySqlDialect.Provider);
				
			Container.Register<ICacheClient>(new MemoryCacheClient());
			Container.RegisterValidators(typeof(MainServices).Assembly);
			Container.Register<IDbConnectionFactory>(c => conn);
			Container.Register(c => new UsersControlSettingsRepository() {
				Conn = c.TryResolve<IDbConnectionFactory>()
			});
			
			// Setup authentication
			Plugins.Add(new AuthFeature(
				() => new AuthUserSession(),
				new IAuthProvider[] { new CustomCredentialsAuthProvider()}
			));
		}
	}
