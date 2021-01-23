        public int ExecuteNonQueryInt(string commandString, bool isStoredProc = false, params object[] param)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection("Your connection string here"))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = commandString;
                        cmd.CommandType = isStoredProc ? CommandType.StoredProcedure : CommandType.Text;
                        foreach (var parm in param)
                        {
                            cmd.Parameters.Add(parm);
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }
