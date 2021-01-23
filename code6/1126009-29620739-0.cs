               SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["mySQLConnection"].ToString();
                con.Open();
                // As per @fubo's comment
                SqlCommand cmd = new SqlCommand("SELECT uname, mydata,mynewdata FROM vusers u JOIN vdata v ON u.uname = v.uname JOIN vnewdata n ON u.uname = n.uname", con);
                using (var dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var getmydata = dr["mydata"].ToString();
                            var getmynewdata = dr["mydata"].ToString();
                        }
                    }
