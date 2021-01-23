     string txtSearch = txtSearchRP.Text;
            SqlDataReader dr;
            using (SqlConnection conn = new SqlConnection(cn.ConnectionString))
            {
                using (SqlCommand cmdd = new SqlCommand())
                {
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.CommandText = "sp_Search";
                    cmdd.Parameters.AddWithValue("@txtSearch", txtSearch);
                    cmdd.Connection = conn;
                    conn.Open();
                    dr = cmdd.ExecuteReader(CommandBehavior.CloseConnection);
    
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var name = dr["name"].ToString();
                            var location = dr["location"].ToString();
                        }
                    } dr.Close();
                    conn.Close();
    
                }
            }
