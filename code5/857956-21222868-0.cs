     public System.Data.DataSet MyDataSet()
     {
          // da_1 is delcared in this method.. it is only available here
          ...
          System.Data.SqlClient.SqlDataAdapter da_1 = new
                              System.Data.SqlClient.SqlDataAdapter(sql_string, con);
          ...
     } 
     public void UpdateDatabase(System.Data.DataSet ds)
     {
          // not available here
     }
