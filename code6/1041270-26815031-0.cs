     DataTable dt = new DataTable();
            using (var conn = new SqlConnection(connectionLib))
            {
                try
                {
                    using (var cmd = new SqlCommand(Query, conn))
                    {
                        
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        conn.Close();
                        da.Dispose();
                    }
                }
                catch
                {
                }
            }
