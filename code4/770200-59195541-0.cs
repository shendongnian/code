    var result = await 
     dbManager.ExecuteFunctionResultAsync<Oracle.ManagedDataAccess.Types.OracleDecimal>(
                         functionName, parameters.List);
    public async Task<T> ExecuteFunctionResultAsync<T>(string spName, IEnumerable<OracleParameter> paramaters)
            {
                using (OracleConnection connection = new OracleConnection(this.connectionString))
                {
                    connection.Open();
                    using (OracleCommand comm = new OracleCommand(spName, connection))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.BindByName = true;
                        string returnParam = "return_value";
                        comm.Parameters.Add(new OracleParameter() {
                            ParameterName = returnParam,
                            Direction = ParameterDirection.ReturnValue,
                            OracleDbType = OracleDbType.Int16,
                        });
    
                        this.SetCommandParameters(comm, paramaters);
                        await comm.ExecuteNonQueryAsync();
                        var result = (T)comm.Parameters[returnParam].Value;
    
                        return result;
                    }
                }
            }
    private void SetCommandParameters(OracleCommand command, IEnumerable<OracleParameter> paramaters)
            {
                if (paramaters != null)
                {
                    foreach (OracleParameter p in paramaters)
                    {
                        command.Parameters.Add(p);
                    }
                }
            }
