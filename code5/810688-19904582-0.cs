    protected override Connection CreateObjectContext()
            {
    
    
                // Start out by creating the SQL Server connection string
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
    
                // Set the properties for the data source. The IP address network address
                sqlBuilder.DataSource = @"10.10.10.10";
                // The name of the database on the server
                sqlBuilder.InitialCatalog = "Development";
                sqlBuilder.IntegratedSecurity = true;
                sqlBuilder.MultipleActiveResultSets = true;
                sqlBuilder.ApplicationName = "EntityFramework";
                // Now create the Entity Framework connection string
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                //Set the provider name.
                entityBuilder.Provider = "System.Data.SqlClient";
                // Set the provider-specific connection string.
                entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
    
                // Set the Metadata location. 
                entityBuilder.Metadata = @"res://*/Entities.Permission.csdl|res://*/Entities.Permission.ssdl|res://*/Entities.Permission.msl";
    
                // Create and entity connection
                EntityConnection conn = new EntityConnection(entityBuilder.ToString());
    
                return new Connection(conn);
    
            }
