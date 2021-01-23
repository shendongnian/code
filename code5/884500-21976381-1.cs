    public virtual async Task<T> Get(int id)
        where T : IDataModel, new()
    {
        var connection = await GetConnection();
        return await connection.Table<T>()
                .Where(item => ((IDataModel)item).Id == id)
                .FirstOrDefaultAsync();
    }
