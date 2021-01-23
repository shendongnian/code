                OracleCommand chkCmd = null;
                try
                {
                    chkCmd = new OracleCommand();
                    chkCmd.CommandText = "login";
                    chkCmd.CommandType = CommandType.StoredProcedure;
				
                chkCmd.Connection = conn;
                OracleParameter mobParam1 = new OracleParameter("p_Naam", OracleDbType.Varchar2, 2000);
                mobParam1.Direction = ParameterDirection.Input;
                mobParam1.Value = gebruikersnaam;
				OracleParameter mobParam2 = new OracleParameter("p_Wachtwoord", OracleDbType.Varchar2, 2000);
                mobParam2.Direction = ParameterDirection.Input;
                mobParam2.Value = wachtwoord;
                OracleParameter retValue = new OracleParameter("returnVal", OracleDbType.Varchar2, 2000);
                retValue.Direction = ParameterDirection.ReturnValue;
                
                
                chkCmd.Parameters.Clear();
                chkCmd.Parameters.Add(retValue);
                chkCmd.Parameters.Add(mobParam1);
				chkCmd.Parameters.Add(mobParam2);
                con.Open();
                chkCmd.ExecuteScalar();
                string retmsg = Convert.ToString(retValue.Value);
                
                return retmsg=="t";
            }
            finally 
            {
                con.Close();
                chkCmd.Dispose();
                con.Dispose();
            }
