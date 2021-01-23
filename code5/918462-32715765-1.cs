    public class SagaPersistenceHandler
	{
		public static ISessionFactory CreateSessionFactory()
		{
			var provider = new SqlServerSessionFactoryProvider(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString, new[]
			{
				typeof (MySagaMap)
			});
			return provider.GetSessionFactory();
		}
	}
