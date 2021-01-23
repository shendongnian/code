    public static bool IsTableEmpty(string tableName)
    {
        string cs = "Server=localhost;Database=test;Uid=root;Pwd=sesame;";
        using (var conn = new MySqlConnection(cs))
        {
           conn.Open();
           string sql = string.Format("SELECT 1 FROM {0}", tableName);
           using (var cmd = new MySqlCommand(sql, conn))
           {
              using (var reader = cmd.ExecuteReader())
              {
                 return !reader.HasRows;
              }
           }
        }
    }
