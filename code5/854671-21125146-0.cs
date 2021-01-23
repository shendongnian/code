    public DataTable runQuery(string qry)
    {
        DataTable dt = new DataTable();
        cmd.CommandText = qry;
        con.Open();
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        dt.Load(rdr);
        con.Close();
        return dt;
    }
