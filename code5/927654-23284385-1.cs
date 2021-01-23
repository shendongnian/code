     var cmd = new OracleCommand("SOME_PROCEDURE_WRAPPER", _connection);
     cmd.CommandType = CommandType.StoredProcedure;
     string @string = statusData.ToHexString();
     OracleParameter sessionId = new OracleParameter("dbSessionId", OracleDbType.Decimal, new OracleDecimal(_dbSessionId), ParameterDirection.Input);                
     OracleParameter data = new OracleParameter("statusData", OracleDbType.Varchar2,@string.Length, new OracleString(@string), ParameterDirection.Input);
     cmd.Parameters.Add(sessionId);
     cmd.Parameters.Add(data);
     cmd.ExecuteNonQuery();
