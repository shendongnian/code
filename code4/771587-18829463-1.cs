    public string GetConnectionString()
    {
        var builder = new SqlConnectionStringBuilder();
        builder.DataSource = ConfigurationManager.AppSettings["dbServer"];
        builder.InitialCatalog = ConfigurationManager.AppSettings["dbName"];
        builder.IntegratedSecurtiy = Convert.ToBoolean(ConfigurationManager.AppSettings["integratedSecurity"]);
        string user = ConfigurationManager.AppSettings["user"];
        string pwd = ConfigurationManager.AppSettings["pwd"]
        if(!string.IsNullOrEmpty(user))
        {
           builder.UserId = user;
           builder.Password = YourCryptoProvider.Decrypt(pwd);
        }
        return builder.ToString()
    }
