    public class EFLoggerForTesting : IDbCommandInterceptor
    {
        static readonly ConcurrentDictionary<DbCommand, DateTime> m_StartTime = new ConcurrentDictionary<DbCommand, DateTime>();
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Log(command, interceptionContext);
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Log(command, interceptionContext);
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Log(command, interceptionContext);
        }
        private static void Log<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            DateTime startTime;
            TimeSpan duration;
            m_StartTime.TryRemove(command, out startTime);
            if (startTime != default(DateTime))
            {
                duration = DateTime.Now - startTime;
            }
            else
                duration = TimeSpan.Zero;
            var requestId =-1;
            string message;
            var parameters = new StringBuilder();
            foreach (DbParameter param in command.Parameters)
            {
                parameters.AppendLine(param.ParameterName + " " + param.DbType + " = " + param.Value);
            }
            if (interceptionContext.Exception == null)
            {
                message = string.Format("Database call took {0} sec. RequestId {1} \r\nCommand:\r\n{2}", duration.TotalSeconds.ToString("N3"), requestId, parameters.ToString() + command.CommandText);
            }
            else
            {
                message = string.Format("EF Database call failed after {0} sec. RequestId {1} \r\nCommand:\r\n{2}\r\nError:{3} ", duration.TotalSeconds.ToString("N3"), requestId, parameters.ToString() + command.CommandText, interceptionContext.Exception);
            }
            Debug.WriteLine(message);
        }
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            OnStart(command);
        }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            OnStart(command);
        }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            OnStart(command);
        }
        private static void OnStart(DbCommand command)
        {
            m_StartTime.TryAdd(command, DateTime.Now);
        }
    }
