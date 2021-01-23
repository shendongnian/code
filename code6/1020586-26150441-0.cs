    public static async Task<IDataReader> ExecuteReaderAsync(this IDbCommand self)
    {
        var dbCommand = self as DbCommand;
        if (dbCommand != null)
        {
            return await dbCommand.ExecuteReaderAsync();
        }
            
        return await Task.Run(() => self.ExecuteReader());
    }
