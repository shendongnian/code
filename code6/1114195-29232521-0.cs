    using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Hunt_Lisa"].ConnectionString);
                    cmd.CommandText = "blkFinance_noheader";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Path", SqlDbType.Text).Value = fn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
