    using (SqlCeConnection oConn = new SqlCeConnection(ConnectionString))
    using (SqlCeCommand command = new SqlCeCommand("INSERT INTO ..", oConn ))
    {
        oConn.Open();
        command.ExecuteNonQuery()     
    }
