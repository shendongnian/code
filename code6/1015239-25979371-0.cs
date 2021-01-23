    public class SqlCommandWrapper
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        public SqlCommandWrapper(ISettings settings, ILogger logger)
        {
            _settings = settings;
            _logger = logger;
        }
        public enum ExecutionType
        {
            Reader,
            NonQuery,
            Scaler
        }
        public Task<IEnumerable<T>> ExecuteReaderAsync<T>(string commandText, Func<IDataReader, T> callback, params SqlParameter[] parameters)
        {
            return ExecuteReaderAsync(CommandType.StoredProcedure, commandText, callback, parameters);
        }
        public Task<IEnumerable<T>> ExecuteReaderAsync<T>(CommandType commandType, string commandText, Func<IDataReader, T> callback, params SqlParameter[] parameters)
        {
            return ExecuteReaderAsync(ExecutionType.Reader, commandType, commandText, IsolationLevel.ReadUncommitted, callback, parameters);
        }
        public async Task<IEnumerable<T>> ExecuteReaderAsync<T>(ExecutionType executionType, CommandType commandType, string commandText, IsolationLevel isolationLevel,
            Func<IDataReader, T> callback, params SqlParameter[] parameters)
        {
            return (IEnumerable<T>)await ExecuteAsync(executionType, commandType, commandText, isolationLevel, parameters, callback).ConfigureAwait(false);
        }
        public Task<int> ExecuteNonQueryAsync(string commandText, params SqlParameter[] parameters)
        {
            return ExecuteNonQueryAsync(CommandType.StoredProcedure, commandText, parameters);
        }
        public Task<int> ExecuteNonQueryAsync(CommandType commandType, string commandText, params SqlParameter[] parameters)
        {
            return ExecuteNonQueryAsync(ExecutionType.NonQuery, commandType, commandText, IsolationLevel.ReadUncommitted, parameters);
        }
        public async Task<int> ExecuteNonQueryAsync(ExecutionType executionType, CommandType commandType, string commandText, IsolationLevel isolationLevel, params SqlParameter[] parameters)
        {
            return (int)await ExecuteAsync(executionType, commandType, commandText, isolationLevel, parameters).ConfigureAwait(false);
        }
        public Task<object> ExecuteScalarAsync(string commandText, params SqlParameter[] parameters)
        {
            return ExecuteScalarAsync(CommandType.StoredProcedure, commandText, parameters);
        }
        public Task<object> ExecuteScalarAsync(CommandType commandType, string commandText, params SqlParameter[] parameters)
        {
            return ExecuteScalarAsync(ExecutionType.Scaler, commandType, commandText, IsolationLevel.ReadUncommitted, parameters);
        }
        public Task<object> ExecuteScalarAsync(ExecutionType executionType,CommandType commandType, string commandText, IsolationLevel isolationLevel, params SqlParameter[] parameters)
        {
            return ExecuteAsync(executionType, commandType, commandText, isolationLevel, parameters);
        }
        private Task<object> ExecuteAsync(ExecutionType executionType, CommandType commandType, string commandText, IsolationLevel isolationLevel,
            SqlParameter[] parameters)
        {
            return ExecuteAsync<object>(executionType, commandType, commandText, isolationLevel, parameters);
        }
        private async Task<object> ExecuteAsync<T>(ExecutionType executionType, CommandType commandType, string commandText, IsolationLevel isolationLevel, SqlParameter[] parameters, Func<IDataReader, T> callback = null)
        {
            using (var connection = new SqlConnection(_settings.DatabaseConnectionString))
            {
                using (var command = new SqlCommand(commandText, connection) {CommandType = commandType})
                {
                    command.Parameters.AddRange(parameters);
                    command.CommandTimeout = _settings.CommandTimeout;
                    await connection.OpenAsync().ConfigureAwait(false);
                    var transaction = connection.BeginTransaction(isolationLevel);
                    command.Transaction = transaction;
                    try
                    {
                        object result;
                        switch (executionType)
                        {
                            case ExecutionType.Reader:
                                var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
                                using (reader)
                                {
                                    var list = new List<T>();
                                    while (reader.Read())
                                    {
                                        if (callback != null)
                                        {
                                            list.Add(callback(reader));
                                        }
                                    }
                                    result = list;
                                }
                                break;
                            case ExecutionType.NonQuery:
                                result = await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                                break;
                            default:
                                result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                                break;
                        }
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception exception)
                    {
                        _logger.Log(exception);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
