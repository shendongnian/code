    public DataTable runQuery(string qry)
    {
        var table = new DataTable();
        cmd.CommandText = qry;
        con.Open();
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        table.Load(rdr);
        con.Close();
        return table;
    }
