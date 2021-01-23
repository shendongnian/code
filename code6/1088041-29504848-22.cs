    var providerName = "MySql.Data.MySqlClient";
    var builder = new StringBuilder();
    builder.Append("server=servername;");
    builder.Append("user id=username;");
    builder.Append("password=password;");
    builder.Append("persistsecurityinfo=True;");
    builder.Append("Convert Zero Datetime=True;");
    builder.Append("database=default_db");
    var providerString = builder.ToString();
    
    var entityBuilder = new EntityConnectionStringBuilder();
    entityBuilder.Provider = providerName;
    entityBuilder.ProviderConnectionString = providerString;
    
    entityBuilder.Metadata = @"res://*/DataAccess.entityName.csdl|
                               res://*/DataAccess.entityName.ssdl|
                               res://*/DataAccess.entityName.msl";
    using (var conn = new EntityConnection(entityBuilder.ToString()))
    {
        conn.Open();
        // do something
        conn.Close();
    }
