    static void Main(string[] args)
    {
      using (var conn = new SqlConnection("data source=DBServer; uid=UserName; pwd=Password;"))
      {
        using (var cmd = new SqlCommand())
        {
          conn.Open();
          cmd.Connection = conn;
          cmd.CommandText = "Create Database NewDB;";
          cmd.ExecuteNonQuery();
          cmd.CommandText = "Use NewDB;CREATE TABLE dbo.Table1 (ID int, Data nvarchar(128));";
          cmd.ExecuteNonQuery();
        }
      }
    }
