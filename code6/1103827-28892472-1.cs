    public DataTable fillData(string connection, string tableName)
    {
        DataTable dt = new DataTable();
        try
        {
           using (SqlConnection con = new SqlConnection(connection))
           {
               con.Open();
               using (SqlDataAdapter da = new SqlDataAdapter("select * from " + tableName,con))
               {
                    da.Fill(dt);
               }
           }
         }
         catch(Exception ex)
         {
             //You may log exception here and show some message to user
         }
        return dt;
    }
