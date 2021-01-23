	/// <summary>
	/// Initializes a new instance of the <see cref="DynamicAQDContext"/> class.
	/// </summary>
	public DynamicAQDContext()
	{
		var entityConnection = DatabaseUtils.BuildConnection(new BuildConnectionParams
		{
			ProviderName = "System.Data.SqlClient",
			ServerName = "localhost\\",
			DatabaseName = "",
			ModelName = "YOURMODEL",
			SchemaName = "SCHEMA"
		});
		if(entityConnection == null)
			throw new Exception("Can't create EntityConnection");
		_entities = new LINKEntities(entityConnection);
	}
