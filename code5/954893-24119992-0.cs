    OdbcConnection con = new OdbcConnection(ConnectString);
    con.Open();
    OdbcCommand checkcommand = new OdbcCommand("SELECT contents FROM MyTable WHERE MyClause",  con);
    OdbcDataReader checkreader = checkcommand.ExecuteReader();
    byte[] array = null;
    if (checkreader.Read())
        array = (byte[])checkreader.GetValue(0);
    else
    {
       //Error
       return false;
    }
    
    File.WriteAllBytes("C:\\MyImage.jpeg", array);
