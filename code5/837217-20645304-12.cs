    using(SqlConnection connectionForSQL = new SqlConnection(@"Server=localhost; Integrated Security=SSPI; Database=master"))
    {
         string verifyQuery = string.Format("SELECT database_id FROM sys.databases WHERE NAME = '{0}'", dbName);
         using(SqlCommand verifySqlCommand = new SqlCommand(verifyQuery, connectionForSQL))
         {
            connectionForSQL.Open();
            int databaseId = (int)verifySqlCommand.ExecuteScalar();
            return databaseId > 0;
         }
    }
