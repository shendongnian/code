    var cmd = new OracleCommand("SOME_PROCEDURE", _connection);
    cmd.CommandType = CommandType.StoredProcedure;
    int[] bt = new int[]{1,68,0,83,128,1};
    OracleParameter sessionId = new OracleParameter("dbSessionId", OracleDbType.Decimal, new OracleDecimal(_dbSessionId), ParameterDirection.Input);                
    OracleParameter data = new OracleParameter("statusData", OracleDbType.Raw, new OracleBinary(bt), ParameterDirection.Input);
    cmd.Parameters.Add(sessionId);
    cmd.Parameters.Add(data);
    cmd.ExecuteNonQuery();
