    using (MySqlConnection conn = new MySqlConnection(stringConection))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetItemCount", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;             
                    conn.Open();
                    DataSet ds= new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(ds);
                }
            }
