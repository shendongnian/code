    var param = cmd.Parameters.Add("blobInParam", OracleDbType.Blob);
    param.Direction = ParameterDirection.Input;   
    
    // Assign Byte Array to Oracle Parameter
    param.Value = blobData;
