    private static void CreateSQLDatabase(string webAddress)
    {
       try
       {
          using(SqlConnection connectionForSQL = new SqlConnection(@"Server=localhost; Integrated Security=SSPI; Database=master"))
          {
             string createSQLDb = "CREATE DATABASE " + webAddress;
             using(SqlCommand buildSqlCommand = new SqlCommand(createSQLDb, connectionForSQL))
             {
                connectionForSQL.Open();
                buildSqlCommand.ExecuteNonQuery();
             }
          }
       }
       catch(SqlException ex)
       {
          SqlExceptionHelper.GetSQLExceptionDescription(ex);
       }
    }
