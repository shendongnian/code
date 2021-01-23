    private string GetStateByZipCode(string ZipOrPostalCode, string ST)
        {
            try
            {
                string strServerName = ConfigurationManager.AppSettings["ServerName"];
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyNGConnect_ConnectionString"].ToString()))
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "ngc_GetStateByZipCode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ZipOrPostalCode", ZipOrPostalCode);
                    cmd.Parameters.AddWithValue("@ST", ST);
                    using (SqlDataReader reader = storedProcCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["ZipOrPostalCode"].ToString().Equals(ZipOrPostalCode) &&
                                reader["ST"].ToString().Equals(ST))
                            {
                                return ST;
                            }
                        }
                    }
                }
                finally
                {
                }
            }
        }
