     public DataTable GetData()
     {
         using (SqlConnection con = new SqlConnection("..."))
         {
             return GetData(con);
         }
     }
     public DataTable GetData(SqlConnection con)
     {
          // fetch data
           return dtData;
     }
