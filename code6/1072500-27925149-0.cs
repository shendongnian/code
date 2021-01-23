    using (OracleConnection con = new OracleConnection())
    {
        con.ConnectionString = My_connection_string;               
        con.Open();
        OracleCommand cmd = new OracleCommand("tmp_test", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.BindByName = true;
        var result = cmd.ExecuteScalar();
        
        //it is included dbms_output
        cmd.CommandText = "begin dbms_output.enable (1000); end;";
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
    
        string out_string;
        int status = 0;
        cmd.CommandText = "BEGIN DBMS_OUTPUT.GET_LINE (:out_string, :status); END;";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Clear();
        cmd.Parameters.Add("out_string", OracleType.VarChar, 32000);
        cmd.Parameters.Add("status", OracleType.Double);
        cmd.Parameters[0].Direction = System.Data.ParameterDirection.Output;
        cmd.Parameters[1].Direction = System.Data.ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        out_string = cmd.Parameters[0].Value.ToString();
        status = int.Parse(cmd.Parameters[1].Value.ToString());
    }
