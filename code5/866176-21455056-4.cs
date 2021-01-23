     public void Method4() 
       {
          string sqlStr1 = "my SQL query 1";
          string sqlStr1 = "my SQL query 2";
        
          // Do not forget to configure connection pull so that
          // establishing a connection will not be expensive 
          using (SqlConnection con = new SqlConnection(connectionString))
          {
            con.Open();
                
            // Think on having both queries executed in one transaction
            using (SqlCommand com1 = new SqlCommand(sqlStr1, con))
              com1.ExecuteNonQuery();
    
            using (SqlCommand com1 = new SqlCommand(sqlStr2, con))
              com2.ExecuteNonQuery();
          }
        }
