    public async Task<IList<District>> GetAllDistrictsAsync()
    {
        using (var connection = await GetConnectionAsync())
        {
            return (await connection.QueryAsync<District>("select * from Districts")).ToList();
        }
    }
    
    public async Task<IDbConnection> GetConnectionAsync()
    {
        var connectionString = 
            ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        return connection;
    }
