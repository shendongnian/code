                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string qry = @"UPDATE dbo.RegisterUser SET FullName = @Name, PhoneNo = @PhNo, EmailId = @EID FROM dbo.RegisterUser WHERE UserName = @Name";
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = txtFullName.Text;
                        cmd.Parameters.AddWithValue("@PhNo", SqlDbType.NVarChar).Value = txtPhNo.Text;
                        cmd.Parameters.AddWithValue("@EID", SqlDbType.Int).Value = (int)txtMailID.Text;
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                };
