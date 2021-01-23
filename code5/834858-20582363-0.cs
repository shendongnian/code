      public static DataTable SelectData(string sCommand)
      {
              DataTable dtData = null;
              try
              {
                dtData = new DataTable();
                using (SqlConnection connection = new SqlConnection("your connection string goes here"))
                {
                  using (SqlDataAdapter da = new SqlDataAdapter(sCommand, connection))
                  {
                    connection.Open();
                    da.Fill(dtData);
                  }
                }                    
              }
              catch (Exception e)
              {
                MessageBox.Show(e.Message);
              }         
              return dtData;
       }
