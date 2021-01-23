    var isIdle = true;
    if (isIdle)
            {
                lock (padlock)
                {
                    if (isIdle)
                    {
                      isIdle = false;
    using SqlConnection connection = new SqlConnection(connectionString)
    {
    SqlCommand command = new SqlCommand("SP name here", connection);
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.AddWithValue("@paramName", _param);
    // several other parameters added the same way here
    SqlParameter result = new SqlParameter();
    result.ParameterName = "@result";
    result.DbType = DbType.Boolean;
    result.Direction = ParameterDirection.Output;
    command.Parameters.Add(result);
    connection.Open();
    command.ExecuteNonQuery();
    try { _spresult = (bool)result.Value; }
    catch (InvalidCastException) { return true; }   // this is by design, please don't pester me about it
    }
                    }
                }
            }
            return _spresult;
        }
