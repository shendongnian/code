    public static async Task<int> ExecuteNonQueryAsync(string connectionString,
        CommandType commandType, string commandText, params SqlParameter[] parameters)
    {
        return (int) await ExecuteAsync(ExecutionType.NonQuery, connectionString,
            commandType, commandText, parameters).ConfigureAwait(false);
    }
