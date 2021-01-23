    using Oracle.DataAccess;
    using Oracle.DataAccess.Client;
    
    public DataTable Call_contact_return(string v_urn_value)
                {
                    using (OracleConnection cn = new OracleConnection(DatabaseHelper.GetConnectionString()))
                    {
                        OracleDataAdapter da = new OracleDataAdapter();
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = cn;
                        cmd.InitialLONGFetchSize = 1000;
                        cmd.CommandText = DatabaseHelper.GetDBOwner() + "contact_return";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("v_urn", OracleDbType.Char).Value = v_urn_value;                    
                        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
    
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
