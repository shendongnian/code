    public class QueryOriginInterceptor : IDbCommandInterceptor
    {
        private const string _sqlCommentToken = "--";
        private const string stackLoggerStartTag = _sqlCommentToken + " Stack:";
    
        private bool _shouldLog = false;
    
        public static string StackLoggerStartTag => stackLoggerStartTag;
    
        public QueryOriginInterceptor(bool shouldLog = true)
        {
            _shouldLog = shouldLog;
        }
    
        void AppendStackTraceToSqlCommand(DbCommand command)
        {
            if (!_shouldLog)
                return;
    
            int positionOfExistingCommentStartTag = command.CommandText.IndexOf(stackLoggerStartTag);
    
            if (positionOfExistingCommentStartTag < 0)
            {
                IEnumerable<string> frames = (new StackTrace())
                    .GetFrames()
                    .ToList()
                    .Select(f => $"{f?.GetMethod()?.ReflectedType?.FullName ?? "[unknown]"}.{f?.GetMethod()?.Name}")
                    .Where(l => !l.StartsWith("System.") && !l.StartsWith(this.GetType().FullName));
    
                string comment = $"{stackLoggerStartTag}{Environment.NewLine}{_sqlCommentToken} {string.Join($"{Environment.NewLine}{_sqlCommentToken} ", frames)}{Environment.NewLine}";
                command.CommandText = $"{Environment.NewLine}{comment}{command.CommandText}";
            }
        }
    
        void IDbCommandInterceptor.ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) => AppendStackTraceToSqlCommand(command);
    
        void IDbCommandInterceptor.NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) => AppendStackTraceToSqlCommand(command);
    
        void IDbCommandInterceptor.ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) => AppendStackTraceToSqlCommand(command);
    
        void IDbCommandInterceptor.NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) { }
    
        void IDbCommandInterceptor.ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) { }
    
        void IDbCommandInterceptor.ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) { }
    }
