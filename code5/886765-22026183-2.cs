    using (OdbcConnection cnn = GetConnection())
    using (OdbcCommand cmd = new OdbcCommand(sql, cnn))
    {
        cmd.CommandTimeout = TimeOut;
        cmd.ExecuteNonQuery();
        CloseConnection(cnn);
    }
