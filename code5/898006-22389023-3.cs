    public static int GetTableRowCount(string tableName)
    {
        string cs = "Server=localhost;Database=test;Uid=root;Pwd=sesame;";
        using (var conn = new MySqlConnection(cs))
        {
           conn.Open();
           string sql = string.Format("SELECT COUNT(*) FROM {0}", tableName);
           using (var cmd = new MySqlCommand(sql, conn))
           {
              return Convert.ToInt32(cmd.ExecuteScalar());
           }
        }
    }
