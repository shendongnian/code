    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
    sb.DataSource = ...; //< The `Data Source` parameter
    // The `InitialCatalog` parameter.
    // Create an unique database for testing. And avoid name confliction.
    sb.InitialCatalog = "testing" + Guid.NewGuid().ToString("N"); 
    sb.UserID = ...; //< The `UserId`
    sb.Password = ...; //< The `Password` of `UserId`.
    sb.MultipleActiveResultSets = true;
    SqlConnection dbConn = new SqlConnection(sb.ToString());
    
