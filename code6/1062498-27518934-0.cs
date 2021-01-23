    OracleParameter A1 = OracleParameter("a1", OracleDbType.Varchar2, 1000)
    A1.Direction = ParameterDirection.Input
    A1.Value = params[2]
    OracleCommand.Parameters[0] = A1;
    OracleParameter A2 = OracleParameter("a2", OracleDbType.Varchar2, 1000)
    A1.Direction = ParameterDirection.Input
    A1.Value = params[3]
    OracleCommand.Parameters[1] = A2;
