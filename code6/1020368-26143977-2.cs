    public int AddDataScalar(string strU) {
      using (SqlConnection con = new SqlConnection(strConn)) {
        con.Open();
    
        // Make your SQL readable: use @"" strings
        strQueryExistence = 
          @"SELECT 1
              FROM [OB].[h].[OP_PEONS]
             WHERE Executive = @prm_Executive";
     
        // using is a better practice 
        using (SqlCommand cmd = new SqlCommand(strQueryExistence, con)) {
          // parameters are better than hardcoding
          cmd.Parameters.AddWithValue("@prm_Executive", strU); 
    
          return cmd.ExecuteScalar() == null ? 0 : 1; 
        }
      }
    }
