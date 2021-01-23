		public class Startup
		{
			private HttpConfiguration _configuration;
			[ThreadStatic]
			internal static HttpConfiguration _configurationHolder;
			public static HttpConfiguration CurrentConfiguration
			{
				get { return _configurationHolder; }
				set { _configurationHolder = value; }
			}
			public Startup()
			{
				//get the configuration which is held in a threadstatic variable
				_configuration = _configurationHolder;
			}
			public void Configuration(IAppBuilder appBuilder)
			{
				//do stuff
			}
		}
