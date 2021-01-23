     public object Invoke(String identifier, params object[] args)
            {
                using (var Conn = new OracleConnection(ConnectionString))
                {
                    using (var Command = new OracleCommand())
                    {
                        Command.Connection = Conn;
                        Command.CommandText = "EPA."+ identifier;
                        Command.CommandType = CommandType.StoredProcedure;
                        using (var param = new OracleParameter())
                        {
                            param.OracleDbType = OracleDbType.Int32;
                            param.Direction = ParameterDirection.ReturnValue;
                            param.ParameterName = "return";
                            Command.Parameters.Add(param);
                        }
                        int nCount = 0;
                        foreach(object o in args)
                        {
                            using (var param = new OracleParameter())
                            {
                                param.OracleDbType = GetOracleDbType(o);
                                param.Direction = ParameterDirection.Input;
                                param.ParameterName = "arg" + nCount++;
                                param.Value = o;
                                if(param.OracleDbType != OracleDbType.Date)
                                    Command.Parameters.Add(param);
                                else{
                                    DateTime dt = (DateTime)o;
                                    Command.Parameters.Add(dt.ToString(DateFormat),OracleDbType.Date).Value = dt;
                                }
                            }
                        }
                        Conn.Open();
                        Command.ExecuteNonQuery();
                        return Int32.Parse((Command.Parameters["return"].Value).ToString());
                    }
                }
            }
