    protected void grabData()
    {
        // use the .ConnectionString property to get the connection string!
        string connStr = ConfigurationManager.ConnectionStrings["TFOUNDATION"].ConnectionString;
        SqlCommand cmd = new SqlCommand("SELECT FirstName FROM CauseMarketers", new SqlConnection(connStr));
    }
