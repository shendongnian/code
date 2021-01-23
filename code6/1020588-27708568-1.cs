    public async static Task<IDataReader> ExecuteReaderAsync(this IDbCommand self) {
        DbCommand dbCommand = self as DbCommand;
        if (dbCommand != null) {
            return await dbCommand.ExecuteReaderAsync();
        } else {
            return await Task.Run(() => self.ExecuteReader());
        }
    }
