    string connStr = ".........";
    string result = null;
    using (OracleConnection conn = new OracleConnection(connStr))
    {
        conn.Open();
        using (OracleCommand comm = new OracleCommand("getFreeRfid", conn))
        {
            OracleParameter p = new OracleParameter("rfidout", OracleDbType.Varchar2, ParameterDirection.Output);
            p.Size = 200;
            comm.Parameters.Add(p);
            comm.ExecuteNonQuery();
            result = (string)comm.Parameters[0].Value;
        }
    }
