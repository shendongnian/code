    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
    sb.DataSource = ...; //< The `Data Source` parameter
    // The `InitialCatalog` parameter.
    // Create an unique database for testing. And avoid name confliction.
    sb.InitialCatalog = "testing" + Guid.NewGuid().ToString("N"); 
    sb.UserID = ...; //< The `UserId`
    sb.Password = ...; //< The `Password` of `UserId`.
    sb.MultipleActiveResultSets = true;
    SqlConnection dbConn = new SqlConnection(sb.ToString());
    // dbConn.Open(); 
    // It will be failed when the database had not been created.
    // But, I need to verify the db server, account and password, 
    // no matter whether the database is created or not.
    
