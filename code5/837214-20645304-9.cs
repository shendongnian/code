    private static void CreateSQLDatabase(string dbName)
    {
         string createDb = "CREATE DATABASE @DatabaseName";
         using(SqlCommand buildSqlCommand = new SqlCommand(createDb, connectionForSql))
         {
              buildSqlCommand.Parameters.Add("@DatabaseName", dbName);
              connectionForSQL.Open();
              buildSqlCommand.ExecuteNonQuery();
         }
    }
