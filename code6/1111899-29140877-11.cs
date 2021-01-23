        public static User userLogin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString())
            {
                User U = new User();
                SqlCommand cmd = new SqlCommand(@"SELECT NurseName, password 
                                                    FROM Nurse2 
                                                    WHERE NurseName = @user AND password = @pw", con);
                cmd.Parameters.Add(new SqlParameter("@user", username));
                cmd.Parameters.Add(new SqlParameter("@pw", password));
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("connetion problem", ex);
                }
                try
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            U = rdr["NurseName"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("problem with query", ex);
                }
                finally
                {
                    con.Close(); /* Clean up regardless of the outcome */
                    con.Dispose();
                }
                return U;
            }
        }
