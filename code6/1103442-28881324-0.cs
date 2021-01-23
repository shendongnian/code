    public async Task<Foo> Execute(Foo foo )
    {
        var parameters = new { id = id};
        using (var con = new SqlConnection(this.connectionString))
        {
            var timeout = int.Parse(
                ConfigurationManager.AppSettings["SqlCommandTimeout"]);
            await con.OpenAsync();
            var query = await con.QueryAsync<Foo>(
                "dbo.uspGetMeFoo",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: timeout);
            return query.FirstOrDefault();
        }
    }
