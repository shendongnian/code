	public partial class Tester : DbContext {
		public Tester(string _connectionString)	: base(ConnectionString(_connectionString)) {
			this.Configuration.ProxyCreationEnabled = false;
			this.Configuration.AutoDetectChangesEnabled = false;
		}
		private static string ConnectionString(string _connectionString) {
			EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
			entityBuilder.ProviderConnectionString = _connectionString;
			entityBuilder.Metadata = "res://*/Models.PartsLoaderModel.csdl|res://*/Models.PartsLoaderModel.ssdl|res://*/Models.PartsLoaderModel.msl";
			entityBuilder.Provider = "System.Data.SqlClient";
			return entityBuilder.ToString();
		}	
	}
