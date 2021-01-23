                SqlParameter[] param = {
                                            new SqlParameter("@param1", SqlDbType.VarChar, 100),
                                            new SqlParameter("@param2", SqlDbType.Int),
                                            new SqlParameter("@param3", SqlDbType.DateTime)
                                       };
                //@param1, @param2, @param3 should match your parameters name in stored procedure
    
                param[0].Value = "test"; //pass the value to your parameter here
                param[1].Value = 2;
                param[2].Value = DateTime.Now;
    
                SqlCommand sqlcmd = new SqlCommand();
    
                foreach (SqlParameter x in param)
                {
                    sqlcmd.Parameters.Add(x);
                }
