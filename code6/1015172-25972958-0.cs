    public static async Task<SqlDataReader> ExecuteReaderAsync(
        string connectionString, CommandType commandType,
        string commandText, params SqlParameter[] parameters)
    {
        return (SqlDataReader) await ExecuteAsync(ExecutionType.Reader,
            connectionString, commandType, commandText, parameters);
    }
