    static void Main(string[] args)
    {
      var conn = new SqlConnection("data source=DBServer; uid=UserName; pwd=Password;");
      string sql = "Create Database NewDB; CREATE TABLE dbo.Table1 (ID int, Data, Data nvarchar(128));";
      var cmd = new SqlCommand();
      try
      {
        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = "Create Database NewDB;";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "Use NewDB;CREATE TABLE dbo.Table1 (ID int, Data nvarchar(128));";
        cmd.ExecuteNonQuery();
      }
      finally
      {
        if (conn != null)
          conn.Close();
      }
    }
