     using (SqlConnection conn = new SqlConnection(**"context connection = true"**))
            {            
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Value FROM GlobalConfigSettings WHERE ID = " + ConstFynixConnectionStringId, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    fynixConnString = dr["Value"].ToString();
                }
                conn.Close();                  
            }
