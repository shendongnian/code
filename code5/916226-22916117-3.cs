     using (SqlCommand cmd = new SqlCommand("storedProcedureName",Connection ))
     {
        cmd.CommandType = CommandType.StoredProcedure;                    
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
         {
               DataSet dataset = new DataSet();
               da.Fill(dataset);                       
         }
     }
    to read dataset data
  
      foreach (var table in dataSet.Tables)
       {
           foreach (var row in table.Rows)
            {
                foreach (var column in table.Columns)
                {
                    var UserName= row["UserName"];            
                }
            }
         }
