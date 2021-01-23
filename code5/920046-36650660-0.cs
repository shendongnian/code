    public static async Task<IDataReader> ExecuteReaderAsync(this SqlDatabase database, DbCommand command)
    {
    	return await Task<IDataReader>.Factory.FromAsync(database.BeginExecuteReader, database.EndExecuteReader, command, null);
    }
    
    public static async Task<object> ExecuteScalarAsync(this SqlDatabase database, DbCommand command)
    {
    	return await Task<object>.Factory.FromAsync(database.BeginExecuteScalar, database.EndExecuteScalar, command, null);
    }
    
    public static async Task<XmlReader> ExecuteXmlReaderAsync(this SqlDatabase database, DbCommand command)
    {
    	return await Task<XmlReader>.Factory.FromAsync(database.BeginExecuteXmlReader, database.EndExecuteXmlReader, command, null);
    }
    
    public static async Task<int> ExecuteNonQueryAsync(this SqlDatabase database, DbCommand command)
    {
    	return await Task<int>.Factory.FromAsync(database.BeginExecuteNonQuery, database.EndExecuteNonQuery, command, null);
    }
