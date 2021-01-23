     var builder = new SqlConnectionStringBuilder(
        ConnectionManager.ConnectionStrings["test"].ConnectionString);
     builder.UserID = /* Username specified by user */
     builder.Password = /* Password specified by user */
     string realConnectionString = builder.ConnectionString;
