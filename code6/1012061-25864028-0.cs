    SqlConnectionStringBuilder scsBuilder = new SqlConnectionStringBuilder();
    scsBuilder.UserID = "username";
    scsBuilder.Password = "password";
    scsBuilder.DataSource = "servername or ip address";
    scsBuilder.InitialCatalog = "databasename";
    scsBuilder.IntegratedSecurity = false;
    using (SqlConnection sqlCon = new SqlConnection(scsBuilder.ConnectionString))
    {
      // perform your SQL tasks
    }
