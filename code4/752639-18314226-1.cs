    public class MyPublicAPI
	{
		public MyPublicAPI()
			: this(new Configuration(
				new ConfigurationParser()))
		{
		}
		
		internal MyPublicAPI(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
	}
