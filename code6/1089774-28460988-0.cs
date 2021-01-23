    var ctx = new TestContext();
    var cmd = ctx.Database.Connection.CreateCommand() as OracleCommand;
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "SOMESTOREDPROC";
    var p_rc1 = new OracleParameter("p_rc1", OracleDbType.RefCursor, ParameterDirection.Output);
    var p_rc2 = new OracleParameter("p_rc2", OracleDbType.RefCursor, ParameterDirection.Output);
    cmd.Parameters.Add(p_rc1);
    cmd.Parameters.Add(p_rc2);
    if (ctx.Database.Connection.State != ConnectionState.Open)
        ctx.Database.Connection.Open();
    
    var reader = cmd.ExecuteReader(); 
