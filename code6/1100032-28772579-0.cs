            if (Session["RgId"] == null)
                throw new NullReferenceException("RgId");
            using (var con = new SqlConnection())
            {
                const string sql = "select fullname,emailId from Registration where RgId = @RgId";
                using (var cmd1 = new SqlCommand(sql, con))
                {
                    cmd1.Parameters.Add(new SqlParameter("RdId", SqlDbType.Int) {Value = Session["RgId"]});
                    con.Open();
                    using (var rdr = cmd1.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (rdr.Read())
                        {
                            Label4.Text = (string) rdr["fullname"];
                            label5.Text = (string) rdr["emailId"];
                        }
                        else
                        {
                            //handle registration not found
                        }
                        rdr.Close();
                    }
                }
            }
