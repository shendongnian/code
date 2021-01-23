    Dim nCount As Integer
    
    sSQL = "SELECT COUNT(*) FROM USERS WHERE USER_ID = :UID"
    
    OracleConnection conn = new OracleConnection(ConfigurationSettings.AppSettings("connString"));
    conn.Open();
    OracleCommand cmd = new OracleCommand(sSQL, conn);
    
    cmd.CommandType = CommandType.Text;
    
    cmd.Parameters.Add("UID", OracleType.VarChar).Value = txtUserID.Text;
    
    nCount = cmd.ExecuteScalar();
