		public class ConnectionStringManager : IConnectionStringManager
		{
			private readonly IConfigurationProfileProvider<CustomerProfile> _configurationProfileProvider;
			public ConnectionStringManager(IConfigurationProfileProvider<CustomerProfile> configurationProfileProvider)
			{
				_configurationProfileProvider = configurationProfileProvider;
			}
			public string GetConnectionString()
			{
				return _configurationProfileProvider.GetProfile().CustomerDatabaseConnectionString;
			}
		}  
