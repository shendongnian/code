    public class SqlMonitorInterceptor : IDbCommandInterceptor
    {
        private static readonly ILog logger = LogManager.GetCurrentClassLogger();
        private static readonly int sqlWarningThresholdMs = int.Parse(ConfigurationManager.AppSettings["sqlPerformance_warningThresholdMilliseconds"]);
        private readonly Stopwatch _stopwatch = new Stopwatch();
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            CommandExecuting();
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            CommandExecuted(command, interceptionContext);
        }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            CommandExecuting();
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            CommandExecuted(command, interceptionContext);
        }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            CommandExecuting();
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            CommandExecuted(command, interceptionContext);
        }
        private void CommandExecuting() {
            _stopwatch.Restart();
        }
        private void CommandExecuted<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            _stopwatch.Stop();
            LogIfError(command, interceptionContext);
            LogIfTooSlow(command, _stopwatch.Elapsed);
        }
        private void LogIfError<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if (interceptionContext.Exception != null)
            {
                logger.ErrorFormat("Command {0} failed with exception {1}",
                    command.CommandText, interceptionContext.Exception);
            }
        }
        private void LogIfTooSlow(DbCommand command, TimeSpan completionTime)
        {
            if (completionTime.TotalMilliseconds > sqlWarningThresholdMs)
            {
                logger.WarnFormat("Query time ({0}ms) exceeded the threshold of {1}ms. Command: \"{2}\"",
                    completionTime.TotalMilliseconds, sqlWarningThresholdMs, command.CommandText);
            }
        }
    }
  
