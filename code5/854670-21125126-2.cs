    public DataTable runQuery(string qry)
    {
        var table = new DataTable();
        using (var connection = new SqlConnection(connectionString))
        using (var cmd = con.CreateCommand())
        {
            cmd.CommandText = qry;
            connection.Open();
            using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                table.Load(rdr);
            }
        }
        return table;
    }
