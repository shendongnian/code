    internal static class DatabaseUtils
    {
    	/// <summary>
    	/// Builds the connection string for Entity framework.
    	/// </summary>
    	/// <returns></returns>
    	public static EntityConnection BuildConnection(BuildConnectionParams buildConnectionParams)
    	{
    		var sqlBuilder = new SqlConnectionStringBuilder
    			{
    				DataSource = buildConnectionParams.ServerName,
    				InitialCatalog = buildConnectionParams.DatabaseName,
    				IntegratedSecurity = true
    			};
    
    		var providerString = sqlBuilder.ToString();
    		var entityBuilder = new EntityConnectionStringBuilder
    		{
    			Provider = buildConnectionParams.ProviderName,
    			ProviderConnectionString = providerString,
    			Metadata = string.Format(@"res://*/{0}.csdl|
    						res://*/{0}.ssdl|
    						res://*/{0}.msl", buildConnectionParams.ModelName)
    		};
    
    		return CreateConnection(buildConnectionParams.SchemaName, entityBuilder, buildConnectionParams.ModelName);
    	}
    
    
    	/// <summary>
    	/// Creates the EntityConnection, based on new schema & existing connectionString
    	/// </summary>
    	/// <param name="schemaName">Name of the schema.</param>
    	/// <param name="connectionBuilder"></param>
    	/// <param name="modelName">Name of the model.</param>
    	/// <returns></returns>
    	private static EntityConnection CreateConnection(string schemaName, EntityConnectionStringBuilder connectionBuilder, string modelName)
    	{
    		Func<string, Stream> generateStream =
    			extension => Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Concat(modelName, extension));
    
    		Action<IEnumerable<Stream>> disposeCollection = streams =>
    		{
    			if (streams == null)
    				return;
    
    			foreach (var stream in streams.Where(stream => stream != null))
    				stream.Dispose();
    		};
    
    		var conceptualReader = generateStream(".csdl");
    		var mappingReader = generateStream(".msl");
    		var storageReader = generateStream(".ssdl");
    
    		if (conceptualReader == null || mappingReader == null || storageReader == null)
    		{
    			disposeCollection(new[] { conceptualReader, mappingReader, storageReader });
    			return null;
    		}
    
    		var storageXml = XElement.Load(storageReader);
    
    		foreach (var entitySet in storageXml.Descendants())
    		{
    			var schemaAttribute = entitySet.Attributes("Schema").FirstOrDefault();
    			if (schemaAttribute != null)
    				schemaAttribute.SetValue(schemaName);
    		}
    
    		storageXml.CreateReader();
    
    		var workspace = new MetadataWorkspace();
    
    		var storageCollection = new StoreItemCollection(new[] { storageXml.CreateReader() });
    		var conceptualCollection = new EdmItemCollection(new[] { XmlReader.Create(conceptualReader) });
    		var mappingCollection = new StorageMappingItemCollection(conceptualCollection, 
    																storageCollection,
    																new[] { XmlReader.Create(mappingReader) });
    
    		workspace.RegisterItemCollection(conceptualCollection);
    		workspace.RegisterItemCollection(storageCollection);
    		workspace.RegisterItemCollection(mappingCollection);
    
    		var connection = DbProviderFactories.GetFactory(connectionBuilder.Provider).CreateConnection();
    		if (connection == null)
    		{
    			disposeCollection(new[] { conceptualReader, mappingReader, storageReader });
    			return null;
    		}
    
    		connection.ConnectionString = connectionBuilder.ProviderConnectionString;
    		return new EntityConnection(workspace, connection);
    	}
    }
