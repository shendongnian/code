      public class SqlManager
      {
          private String connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Majel\Tic Tac    Toe\Database\data.accdb";
          
          public static GetOleDbConnection(OleDbCommand cmd)
          {
              if(cmd.Connection == null)
              {
                   OleDbConnection conn = new OleDbConnection(connectionString);
                   conn.Open();
                   cmd.Connection = conn;
                   return conn;
              }
              
              return cmd.Connection;
          }
          public static int ExecuteNonQuery(SqlCommand cmd)
          {
               OleDbConnection conn = GetSqlConnection(cmd);
               try
               {
                  return cmd.ExecuteNonQuery();
               }
               catch
               {
                  throw;
               }
               finally
               {
                  conn.Close();
               }
        
          }
        public static DataSet GetDataSet(SqlCommand cmd)
        {
            return GetDataSet(cmd, "Table");
        }
        public static DataSet GetDataSet(SqlCommand cmd, string defaultTable)
        {
            OleDbConnection conn = GetSqlConnection(cmd);
            try
            {
                DataSet resultDst = new DataSet();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                {
                    adapter.Fill(resultDst, defaultTable);
                }
                return resultDst;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
          
      }
