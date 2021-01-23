    class Database
    {
       public DataSet GetData()
       {
          string connStr = "server=localhost;user=steven;password=12345;database=exercises;";
          MySqlConnection conn = new MySqlConnection(connStr);
          DataSet result = new DataSet();
          try
          {
             conn.Open();
             MySqlDataAdapter reader = new MySqlDataAdapter("SELECT * FROM invoice", conn);
             reader.Fill(result, "invoice");
          }
          catch
          {
             // error handling here
          }
          finally
          {
            conn.Close();
          }
          return result;
       }
    }
