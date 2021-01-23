    public static DataTable GetActiveConnections()
            {
                DataTable objResult = new DataTable();
                try
                {
                    using (SqlConnection conection = new SqlConnection("ConnectionSetting"))
                    {
                        conection.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_who", conection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            using (SqlDataAdapter adpter = new SqlDataAdapter())
                            {
                                adpter.SelectCommand = cmd;
                                adpter.Fill(objResult);
                            }
                        }
                    }
                }
                catch (Exception)
                {
    
                    throw;
                }
    
                return objResult;
    
            }
