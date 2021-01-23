    public class DBUtility 
    {
         public static DbConnection GetOpenConnection()
         {
              var conn = new DBConnection(connectionString); //or whatever type
              conn.Open();
              return conn;
         }
    }
