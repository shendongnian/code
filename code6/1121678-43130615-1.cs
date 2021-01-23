    using (OracleConnection connection = new OracleDbConnector().OracleConnection)
    using (OracleCommand cmd = connection.CreateCommand())
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "MyFunction";
        cmd.Parameters.Add("returnVal", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
        cmd.Parameters["returnVal"].Size = 200;
        cmd.Parameters.Add("application", OracleDbType.Varchar2, "InputValue", ParameterDirection.Input);
        cmd.ExecuteNonQuery();
        string returnValue = cmd.Parameters["returnVal"].Value.ToString();
    }
