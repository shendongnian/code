     using (SqlCommand cmd = new SqlCommand("storedProcedureName",Connection ))
     {
        cmd.CommandType = CommandType.StoredProcedure;                    
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
         {
               DataSet dataset = new DataSet();
               da.Fill(dataset);                       
         }
     }
            
        
