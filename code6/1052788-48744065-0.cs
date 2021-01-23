    public class CustomDatabaseLogFormatter : IDbCommandInterceptor, IDbConnectionInterceptor
    {
        private readonly Action<string> _writeAction;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        /// <summary>
        /// Creates a formatter that will log every command from any context and also commands that do not originate from a context.
        /// </summary>
        /// <remarks>
        /// This constructor is not used when a delegate is set on <see cref="Database.Log" />. Instead it can be
        /// used by setting the formatter directly using <see cref="DbInterception.Add" />.
        /// </remarks>
        /// <param name="writeAction">The delegate to which output will be sent.</param>
        public CustomDatabaseLogFormatter(Action<string> writeAction)
        {
            Check.NotNull(writeAction, "writeAction");
            _writeAction = writeAction;
        }
        internal Action<string> WriteAction
        {
            get { return _writeAction; }
        }
        /// <summary>
        /// Writes the given string to the underlying write delegate.
        /// </summary>
        /// <param name="output">The string to write.</param>
        protected virtual void Write(string output)
        {
            _writeAction(output);
        }
        /// <summary>
        /// The stopwatch used to time executions. This stopwatch is started at the end of
        /// <see cref="NonQueryExecuting" />, <see cref="ScalarExecuting" />, and <see cref="ReaderExecuting" />
        /// methods and is stopped at the beginning of the <see cref="NonQueryExecuted" />, <see cref="ScalarExecuted" />,
        /// and <see cref="ReaderExecuted" /> methods. If these methods are overridden and the stopwatch is being used
        /// then the overrides should either call the base method or start/stop the stopwatch themselves.
        /// </summary>
        /// <returns>The stopwatch.</returns>
        protected internal Stopwatch Stopwatch
        {
            get { return _stopwatch; }
        }
        private void RestartStopwatch()
        {
            Stopwatch.Restart();
        }
        private void StopStopwatch()
        {
            Stopwatch.Stop();
        }
        #region IDbCommandInterceptor
        /// <summary>
        /// This method is called before a call to <see cref="DbCommand.ExecuteNonQuery" /> or
        /// one of its async counterparts is made.
        /// Starts the stopwatch returned from <see cref="Stopwatch"/>.
        /// </summary>
        /// <param name="command">The command being executed.</param>
        /// <param name="interceptionContext">Contextual information associated with the call.</param>
        public virtual void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Check.NotNull(command, "command");
            Check.NotNull(interceptionContext, "interceptionContext");
            RestartStopwatch();
        }
        /// <summary>
        /// This method is called after a call to <see cref="DbCommand.ExecuteNonQuery" /> or
        /// one of its async counterparts is made.
        /// Stops the stopwatch returned from <see cref="Stopwatch"/> and calls <see cref="Executed" />.
        /// </summary>
        /// <param name="command">The command being executed.</param>
        /// <param name="interceptionContext">Contextual information associated with the call.</param>
        public virtual void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Check.NotNull(command, "command");
            Check.NotNull(interceptionContext, "interceptionContext");
            StopStopwatch();
            Executed(command, interceptionContext);
        }
        /// <summary>
        /// This method is called before a call to <see cref="DbCommand.ExecuteReader(CommandBehavior)" /> or
        /// one of its async counterparts is made.
        /// Starts the stopwatch returned from <see cref="Stopwatch"/>.
        /// </summary>
        /// <param name="command">The command being executed.</param>
        /// <param name="interceptionContext">Contextual information associated with the call.</param>
        public virtual void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Check.NotNull(command, "command");
            Check.NotNull(interceptionContext, "interceptionContext");
            RestartStopwatch();
        }
        /// <summary>
        /// This method is called after a call to <see cref="DbCommand.ExecuteReader(CommandBehavior)" /> or
        /// one of its async counterparts is made.
        /// Stops the stopwatch returned from <see cref="Stopwatch"/> and calls <see cref="Executed" />.
        /// </summary>
        /// <param name="command">The command being executed.</param>
        /// <param name="interceptionContext">Contextual information associated with the call.</param>
        public virtual void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Check.NotNull(command, "command");
            Check.NotNull(interceptionContext, "interceptionContext");
            StopStopwatch();
            Executed(command, interceptionContext);
        }
        /// <summary>
        /// This method is called before a call to <see cref="DbCommand.ExecuteScalar" />  or
        /// one of its async counterparts is made.
        /// Starts the stopwatch returned from <see cref="Stopwatch"/>.
        /// </summary>
        /// <param name="command">The command being executed.</param>
        /// <param name="interceptionContext">Contextual information associated with the call.</param>
        public virtual void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Check.NotNull(command, "command");
            Check.NotNull(interceptionContext, "interceptionContext");
            RestartStopwatch();
        }
        /// <summary>
        /// This method is called after a call to <see cref="DbCommand.ExecuteScalar" />  or
        /// one of its async counterparts is made.
        /// Stops the stopwatch returned from <see cref="Stopwatch"/> and calls
        /// <see cref="Executed" />.
        /// </summary>
        /// <param name="command">The command being executed.</param>
        /// <param name="interceptionContext">Contextual information associated with the call.</param>
        public virtual void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Check.NotNull(command, "command");
            Check.NotNull(interceptionContext, "interceptionContext");
            StopStopwatch();
            Executed(command, interceptionContext);
        }
        /// <summary>
        /// Called whenever a command has completed executing. Calls <see cref="LogResult" />.
        /// </summary>
        /// <typeparam name="TResult">The type of the operation's results.</typeparam>
        /// <param name="command">The command that was executed.</param>
        /// <param name="interceptionContext">Contextual information associated with the command.</param>
        public virtual void Executed<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            Check.NotNull(command, "command");
            Check.NotNull(interceptionContext, "interceptionContext");
            LogResult(command, interceptionContext);
        }
        /// <summary>
        /// Called to log the result of executing a command.
        /// </summary>
        /// <typeparam name="TResult">The type of the operation's results.</typeparam>
        /// <param name="command">The command being logged.</param>
        /// <param name="interceptionContext">Contextual information associated with the command.</param>
        public virtual void LogResult<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            Check.NotNull(command, "command");
            Check.NotNull(interceptionContext, "interceptionContext");
            var stopwatch = Stopwatch;
            if (interceptionContext.Exception != null)
            {
                Write(
                    String.Format(StringResources.CommandLogFailed, stopwatch.ElapsedMilliseconds, interceptionContext.Exception.Message)
                    );
            }
            else if (interceptionContext.TaskStatus.HasFlag(TaskStatus.Canceled))
            {
                Write(String.Format(StringResources.CommandLogCanceled, stopwatch.ElapsedMilliseconds));
            }
            else
            {
                var result = interceptionContext.Result;
                var resultString = (object)result == null
                    ? "null"
                    : (result is DbDataReader)
                        ? result.GetType().Name
                        : result.ToString();
                Write(String.Format(StringResources.CommandLogComplete, stopwatch.ElapsedMilliseconds, resultString));
            }
        }
        #endregion
        #region IDbConnectionInterceptor
        public void BeginningTransaction(DbConnection connection, BeginTransactionInterceptionContext interceptionContext)
        { }
        public void BeganTransaction(DbConnection connection, BeginTransactionInterceptionContext interceptionContext)
        { }
        public void Closing(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
        { }
        /// <summary>
        /// Called after <see cref="DbConnection.Close" /> is invoked.
        /// </summary>
        /// <param name="connection">The connection that was closed.</param>
        /// <param name="interceptionContext">Contextual information associated with the call.</param>
        public void Closed(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
        {
            Check.NotNull(connection, "connection");
            Check.NotNull(interceptionContext, "interceptionContext");
            if (interceptionContext.Exception != null)
            {
                Write(String.Format(StringResources.ConnectionCloseErrorLog, DateTimeOffset.UtcNow, interceptionContext.Exception.Message));
            }
            else
            {
                Write(String.Format(StringResources.ConnectionClosedLog, DateTimeOffset.UtcNow));
            }
        }
        public void ConnectionStringGetting(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext)
        { }
        public void ConnectionStringGot(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext)
        { }
        public void ConnectionStringSetting(DbConnection connection, DbConnectionPropertyInterceptionContext<string> interceptionContext)
        { }
        public void ConnectionStringSet(DbConnection connection, DbConnectionPropertyInterceptionContext<string> interceptionContext)
        { }
        public void ConnectionTimeoutGetting(DbConnection connection, DbConnectionInterceptionContext<int> interceptionContext)
        { }
        public void ConnectionTimeoutGot(DbConnection connection, DbConnectionInterceptionContext<int> interceptionContext)
        { }
        public void DatabaseGetting(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext)
        { }
        public void DatabaseGot(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext)
        { }
        public void DataSourceGetting(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext)
        { }
        public void DataSourceGot(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext)
        { }
        public void Disposing(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
        { }
        public void Disposed(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
        { }
        public void EnlistingTransaction(DbConnection connection, EnlistTransactionInterceptionContext interceptionContext)
        { }
        public void EnlistedTransaction(DbConnection connection, EnlistTransactionInterceptionContext interceptionContext)
        { }
        public void Opening(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
        { }
        /// <summary>
        /// Called after <see cref="DbConnection.Open" /> or its async counterpart is invoked.
        /// </summary>
        /// <param name="connection">The connection that was opened.</param>
        /// <param name="interceptionContext">Contextual information associated with the call.</param>
        public void Opened(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
        {
            Check.NotNull(connection, "connection");
            Check.NotNull(interceptionContext, "interceptionContext");
            if (interceptionContext.Exception != null)
            {
                Write(
                    interceptionContext.IsAsync
                        ? String.Format(StringResources.ConnectionOpenErrorLogAsync,
                            DateTimeOffset.UtcNow, interceptionContext.Exception.Message)
                        : String.Format(StringResources.ConnectionOpenErrorLog, DateTimeOffset.UtcNow, interceptionContext.Exception.Message));
            }
            else if (interceptionContext.TaskStatus.HasFlag(TaskStatus.Canceled))
            {
                Write(String.Format(StringResources.ConnectionOpenCanceledLog, DateTimeOffset.UtcNow));
            }
            else
            {
                Write(
                    interceptionContext.IsAsync
                        ? String.Format(StringResources.ConnectionOpenedLogAsync, DateTimeOffset.UtcNow)
                        : String.Format(StringResources.ConnectionOpenedLog, DateTimeOffset.UtcNow));
            }
        }
        public void ServerVersionGetting(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext)
        { }
        public void ServerVersionGot(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext)
        { }
        public void StateGetting(DbConnection connection, DbConnectionInterceptionContext<ConnectionState> interceptionContext)
        { }
        public void StateGot(DbConnection connection, DbConnectionInterceptionContext<ConnectionState> interceptionContext)
        { } 
        #endregion
    }
_________
    internal class Check
    {
        public static T NotNull<T>(T value, string parameterName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
            return value;
        }
    }
