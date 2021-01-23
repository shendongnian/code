    DataTable test = new DataTable();
            using (SqlConnection conn = new SqlConnection("CONN STRING HERE"))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "do sql stuff";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select * from test";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(test);
                        dgvDataViewer.DataSource = test;
                    }
                }
            }
