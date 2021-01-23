    var conn = new OracleConnection("User Id=xxx;Password=xxx;Server=xxxx;");
    var cmd = new OracleCommand();
    cmd.CommandText = "INSERT INTO TABLENAME (COLUMN) VALUES (:1)";
    cmd.Parameters.Add(new OracleParameter("1",
                                       OracleDbType.Varchar2,
                                       txt.Text,
                                       ParameterDirection.Input));
    cmd.Connection = conn;
    conn.Open();
    try 
    {
      cmd.ExecuteNonQuery();      
    }
    catch 
    {
      MessageBox.Show("Error");
    }
    finally 
    {
      conn.Close();
    }
