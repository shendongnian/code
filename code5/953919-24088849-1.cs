    decimal id_usuario = (decimal)dr.GetInt32(0);
    decimal id_refeicao = (decimal)dtre.GetInt32(0);
    var idUsuarioParameter = new OracleParameter
    {
        ParameterName = "id_usuario",
        OracelDbType = OracleDbType.Decimal,
        Direction = ParameterDirection.Input,
        Value = id_usuario
    };
    var idRefeicaoParameter = new OracleParameter
    {
        ParameterName = "id_refeicao",
        OracelDbType = OracleDbType.Decimal,
        Direction = ParameterDirection.Input,
        Value = id_refeicao 
    };    
    var var1Parameter = new OracleParameter
    {
        ParameterName = "var1",
        //OracelDbType = OracleDbType.Decimal, -- populate with correct oracle type
        Direction = ParameterDirection.Input,
        Value = var1 
    };
    
    connection.Open();
    cmd.Connection = connection;
    cmd.CommandText = "INSERT INTO SER_REFEICAO_USUARIO (USUARIO, REFEICAO,    DATA_HORA,  ORIGEM) VALUES(:id_usuario, :id_refeicao, SYSDATE, :var1 )";
    cmd.Parameters.Add(idUsuarioParameter);
    cmd.Parameters.Add(idRefeicaoParameter);
    cmd.Parameters.Add(var1Parameter);
    cmd.CommandType = CommandType.Text;
    cmd.ExecuteNonQuery();
    connection.Close();
