            using (OracleConnection conn = new OracleConnection("User Id=marketing;Password=SECRET;Data Source=dashworks-db"))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand("GET_ACCOUNT_DETAILSV2", conn))
                {
                    cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("PHONE_NUMBER", "416-123-4567");
                    cmd.Parameters.Add("o_rc", OracleDbType.RefCursor, ParameterDirection.Output);
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet("result");
                        ds.Locale = CultureInfo.InvariantCulture;
                        adapter.Fill(ds);
                    }
                }
            }
