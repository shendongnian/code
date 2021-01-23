    public void Method3() {
      string sqlStr = "my SQL query";
    
      // Do not forget to configure connection pull so that
      // establishing a connection will not be expensive 
      using (SqlConnection con = new SqlConnection(connectionString)) {
        con.Open();
            
        using (SqlCommand com = new SqlCommand(sqlStr, con))
          com.ExecuteNonQuery();
      }
    }
