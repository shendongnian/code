    using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["myConnectionString"]))
    {
      using(SqlCommand sqlCommandConn = new SqlCommand(InsertStatement))
      {
        sqlCommandConn.Connection = conn;
        //TODO: Open connection, Execute queries...
      }
    }
