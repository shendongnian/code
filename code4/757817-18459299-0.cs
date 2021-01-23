    using (SqlConnection con = new SqlConnection(dc.Con))
                {
                    using (SqlCommand cmd = new SqlCommand("insert into ttt values(@paramValue)", con))
                    {
                        
                        cmd.Parameters.AddWithValue("@paramValue", "r=DE'S'C@4593§$%");
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
    
                }
