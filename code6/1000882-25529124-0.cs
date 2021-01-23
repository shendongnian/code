    using (OracleConnection connection = new OracleConnection(connString))
    {
        DataTable dt = new DataTable();
        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = "testpkg.cursor1";
        cmd.CommandType = CommandType.StoredProcedure;
    
        cmd.Parameters.Add("IDp", OracleDbType.Int16);
        cmd.Parameters["IDp"].Direction = ParameterDirection.Input;
        cmd.Parameters["IDp"].Value = ID;
    
        cmd.Parameters.Add("records", OracleDbType.RefCursor);
        cmd.Parameters["records"].Direction = ParameterDirection.Output;
        cmd.Connection = connection;
    
        try
        {
            connection.Open();
            OracleDataAdapter da = new OracleDataAdapter(cmd);        
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
