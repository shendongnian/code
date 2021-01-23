    public sealed class ChangeSchemaNameCommandInterceptor : IDbCommandInterceptor
    {
        private readonly string _schemaName;
        public ChangeSchemaNameCommandInterceptor(string schemaName)
        {
            _schemaName = "[" + schemaName + "].";
        }
        public void ReaderExecuting(DbCommand command, 
               DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (!string.IsNullOrEmpty(_schemaName))
                command.CommandText = command.CommandText
                                             .Replace("[dbo].", _schemaName);
        }
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        { }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        { }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        { }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        { }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        { }
    }
