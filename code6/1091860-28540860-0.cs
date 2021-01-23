    public EntityConnection GetEntityConnection(int? portalId, string modelName)
    {
        var serverName = "";
        var databaseName = "";
        var username = "";
        var password = "";
        var portalConnections = _portalAdminEntities.Portal_connections.SingleOrDefault(m => m.Portal_ID == portalId);
        if (portalConnections != null)
        {
            serverName = portalConnections.PortalServer;
            databaseName = portalConnections.PortalDatabase;
            username = portalConnections.PortalUsername;
            password = portalConnections.PortalPassword;
        }
        Func<string, Stream> generateStream = extension => Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Concat(modelName, extension));
        Action<IEnumerable<Stream>> disposeCollection = streams =>
        {
            if (streams == null)
            {
                return;
            }
            foreach (var stream in streams.Where(stream => stream != null))
            {
                stream.Dispose();
            }
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
            {
                schemaAttribute.SetValue(databaseName);
            }
        }
        storageXml.CreateReader();
        var workspace = new MetadataWorkspace();
        var storageCollection = new StoreItemCollection(new[] { storageXml.CreateReader() });
        var conceptualCollection = new EdmItemCollection(new[] { XmlReader.Create(conceptualReader) });
        var mappingCollection = new StorageMappingItemCollection(conceptualCollection, storageCollection, new[] { XmlReader.Create(mappingReader) });
        workspace.RegisterItemCollection(conceptualCollection);
        workspace.RegisterItemCollection(storageCollection);
        workspace.RegisterItemCollection(mappingCollection);
        const string providerName = "System.Data.SqlClient";
        var sqlBuilder = new SqlConnectionStringBuilder
        {
            DataSource = serverName,
            InitialCatalog = databaseName,
            UserID = username,
            Password = password,
            PersistSecurityInfo = true
        };
        var providerString = sqlBuilder.ToString();
        var entityBuilder = new EntityConnectionStringBuilder
        {
            Provider = providerName,
            ProviderConnectionString = providerString,
            Metadata = string.Format(@"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", modelName)
        };
        var connection = DbProviderFactories.GetFactory(entityBuilder.Provider).CreateConnection();
        if (connection == null)
        {
            disposeCollection(new[] { conceptualReader, mappingReader, storageReader });
            return null;
        }
        connection.ConnectionString = entityBuilder.ProviderConnectionString;
        return new EntityConnection(workspace, connection);
    }
    using (var portalAdminEntities = new PortalAdminEntities(_df.GetEntityConnection(model.Portal_ID, Models.PortalAdmin")))
    {
        portalAdminEntities.InsertPageDetails(model.pageId, portalId, model.title, model.content);
    }
