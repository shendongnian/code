    public async Task<Query> GetSqlServerData(Query query)
    {
        var dt = new DataTable();
        var con = new SqlConnection(query.ConnectionString);
        await con.OpenAsync();
        var cmd = new SqlCommand(query.SelectStatement, con);
        var datareader = await cmd.ExecuteReaderAsync();
        dt.Load(datareader);
        con.Close();
        query.Result = dt;
        return query;
    }
