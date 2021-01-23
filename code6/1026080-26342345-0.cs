    public interface IDatabaseSettings
    {
	  string DbConnectionString { get; set; }
    }
    public class DatabaseSettings : IDatabaseSettings
    {
	  public string DbConnectionString { get; set; }
    }
    public class DatabaseRegistry : Registry
    {
	  public DatabaseRegistry()
	  {
		For<IDatabaseSettings>().Use(c =>
		{
			var setting = c.GetInstance<DatabaseSettings>();
			setting.DbConnectionString =
				System.Configuration.ConfigurationManager.AppSettings["DatabaseSettings.DBConnectionString"];
			return setting;
		});
	  }
    }
