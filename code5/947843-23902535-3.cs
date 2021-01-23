    public string CreateConnectionString(string BasicConnectionString)
    {
        //EntityConnectionFactory 
        var entityConnectionStringBuilder= new EntityConnectionStringBuilder();
        entityConnectionStringBuilder.Provider = "Your Provicer here"      //For me it is "System.Data.SqlClient";
        entityConnectionStringBuilder.ProviderConnectionString = BasicConnectionString;
        entityConnectionStringBuilder.Metadata = "res://*";
        return entityConnectionStringBuilder.ToString();
    }
