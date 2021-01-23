    public OleDbDataReader EseguiReader(string _query, OleDbConnection conn)
    {
        conn.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = _query;
        cmd.Connection = conn;
        return cmd.ExecuteReader();
    }
