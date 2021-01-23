      SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
		DataSource = "SOURAV-PC", // Server name
		InitialCatalog = "efDB",  //Database
                UserID = "sourav",         //Username
                Password = "mypassword",  //Password
            };
            //Build an Entity Framework connection string
            EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata =   "res://*/testModel.csdl|res://*/testModel.ssdl|res://*/testModel.msl",
                ProviderConnectionString = sqlString.ToString()
            };
            return entityString.ConnectionString;
        }
