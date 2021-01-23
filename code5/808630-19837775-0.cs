    try
    {
        OracleConnection con = new OracleConnection();
        con.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.0.0.24)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DEVL)));User Id=aaziz;Password=123211;";
        con.Open();
        string cmdQuery = "Insert into M.person (RED_NO, USED_FLAG) VALUES ('12', '0')";
        OracleCommand cmd = new OracleCommand(cmdQuery);
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        
        
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT NEW QUERY HERE";
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT NEW QUERY HERE";
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT NEW QUERY HERE";
        cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT NEW QUERY HERE";
        cmd.ExecuteNonQuery();
        
        con.Dispose();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
