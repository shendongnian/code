    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
    sb.DataSource = ...; //< The `Data Source` parameter
    sb.InitialCatalog = "testing"; //< The `InitialCatalog` parameter.
    sb.UserID = ...; //< The `UserId`
    sb.Password = ...; //< The `Password` of `UserId`.
    sb.MultipleActiveResultSets = true;
    SqlConnection dbConn = new SqlConnection(sb.ToString());
    
