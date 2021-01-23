	public class EFConfiguration : DbConfiguration
	{
		public EFConfiguration()
		{
			SetDefaultConnectionFactory(new LocalDbConnectionFactory("v.11"));
			
			//HACK
			var EF6ProviderServicesType = typeof(System.Data.SQLite.EF6.SQLiteProviderFactory).Assembly.DefinedTypes.First(x => x.Name == "SQLiteProviderServices");
			var EF6ProviderServices = (DbProviderServices)Activator.CreateInstance(EF6ProviderServicesType);
			SetProviderServices("System.Data.SQLite.EF6", EF6ProviderServices);
			SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
			SetProviderFactory("System.Data.SQLite.EF6", System.Data.SQLite.EF6.SQLiteProviderFactory.Instance);
			SetProviderFactory("System.Data.SQLite", System.Data.SQLite.SQLiteFactory.Instance);
		}
	}
