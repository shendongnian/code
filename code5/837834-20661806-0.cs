    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Directory"].ConnectionString;
    using (var con = new SqlConnection(connectionString))
    {
        ....
    }
