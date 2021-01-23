    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = "function_name";    
    command.Parameters.Add(new OracleParameter
                            {
                                ParameterName = "result",
                                Size = 1,
                                Direction = ParameterDirection.ReturnValue,
                                OracleDbType = OracleDbType.Varchar2
                            });
