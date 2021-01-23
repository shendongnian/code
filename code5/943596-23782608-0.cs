    using (OracleCommand cmd = cnn.CreateCommand())
    {
        OracleParameter status = new OracleParameter(":1", OracleType.VarChar, 32000);
        p_line.Direction = ParameterDirection.Output;
                          
        OracleParameter line = new OracleParameter(":2", OracleType.Double);
        p_status.Direction = ParameterDirection.Output;
    
        OracleParameter stage= new OracleParameter("stage", OracleType.Int16);
        p_country_name.Direction = ParameterDirection.Output;    
        cmd.CommandText = script;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(status);
        cmd.Parameters.Add(line );
        cmd.Parameters.Add(stage);
        cmd.ExecuteNonQuery();
    
        string status = status.Value.ToString();
        string line = line.Value.ToString();
        string stage= stage.Value.ToString();
    }
