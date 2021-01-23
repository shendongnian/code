    OracleConnection connection = (Oracle.DataAccess.Client.OracleConnection)_context.Database.Connection;
    connection.Open();
    OracleCommand cmd = _context.Database.Connection.CreateCommand() as OracleCommand;
    cmd.CommandText = "STORED_PROCEDURE_NAME";
    cmd.CommandType = CommandType.StoredProcedure;
    
    #region Parameters
    
    //original and changed are just some POCOs
    OracleParameter oNameOfParameter = new OracleParameter("oNameOfParameter", OracleDbType.Decimal, original.NameOfParameter, ParameterDirection.Input);
    OracleParameter oNameOfParameter2 = new OracleParameter("oNameOfParameter2", OracleDbType.Varchar2, original.NameOfParameter2, ParameterDirection.Input);
    
    OracleParameter NameOfParameter3 = new OracleParameter("nameOfParameter3", OracleDbType.Varchar2, changed.NameOfParameter3, ParameterDirection.Input);
    OracleParameter NameOfParameter4 = new OracleParameter("nameOfParameter4", OracleDbType.Decimal, changed.NameOfParameter4, ParameterDirection.Input);
    
    cmd.Parameters.Add(nameOfParameter3);
    cmd.Parameters.Add(nameOfParameter4);
    cmd.Parameters.Add(oNameOfParameter);
    cmd.Parameters.Add(oNameOfParameter2);
    
    #endregion Parameters
    
    var i = cmd.ExecuteNonQuery();
    connection.Close();
