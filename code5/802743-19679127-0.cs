                        using (DataContext ctx = new DataContext(mdb.Database.Connection))
                        {
                            DataSet ds = new DataSet();
                            var query = (from j in mdb.tblCountries 
                                         orderby j.CountryName ascending
                                         select j);
                            SqlCommand cmd = (SqlCommand)ctx.GetCommand(query);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(ds);
                            return ds;
                        }
