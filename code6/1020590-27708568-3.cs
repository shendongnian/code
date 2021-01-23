    public async static Task<IDataReader> ExecuteReaderAsync(this IDbCommand self) {
        if (self is DbCommand dbCommand) {
            return await dbCommand.ExecuteReaderAsync();
        } else {
            return await Task.Run(() => self.ExecuteReader());
        }
    }
