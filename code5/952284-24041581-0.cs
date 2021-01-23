    /// <summary>
    /// Helps to extract useful information from SQLExceptions, particularly in SQL Azure
    /// </summary>
    public class SqlExceptionDetails
    {
        public ResourcesThrottled SeriouslyExceededResources { get; private set; }
        public ResourcesThrottled SlightlyExceededResources { get; private set; }
        public OperationsThrottled OperationsThrottled { get; private set; }
        public IList<SqlErrorCode> Errors { get; private set; }
        public string ThrottlingMessage { get; private set; }
        public bool ShouldRetry { get; private set; }
        public bool ShouldRetryImmediately { get; private set; }
        private SqlExceptionDetails()
        {
            this.ShouldRetryImmediately = false;
            this.ShouldRetry = true;
            this.SeriouslyExceededResources = ResourcesThrottled.None;
            this.SlightlyExceededResources = ResourcesThrottled.None;
            this.OperationsThrottled = OperationsThrottled.None;
            Errors = new List<SqlErrorCode>();
        }
        public SqlExceptionDetails(SqlException exception) :this(exception.Errors.Cast<SqlError>())
        {
        }
        public SqlExceptionDetails(IEnumerable<SqlError> errors) : this()
        {
            List<ISqlError> errorWrappers = (from err in errors
                                             select new SqlErrorWrapper(err)).Cast<ISqlError>().ToList();
            this.ParseErrors(errorWrappers);
        }
        public SqlExceptionDetails(IEnumerable<ISqlError> errors) : this()
        {
            ParseErrors(errors);
        }
        private void ParseErrors(IEnumerable<ISqlError> errors)
        {
            foreach (ISqlError error in errors)
            {
                SqlErrorCode code = GetSqlErrorCodeFromInt(error.Number);
                this.Errors.Add(code);
                switch (code)
                {
                    case SqlErrorCode.ServerBusy:
                        ParseServerBusyError(error);
                        break;
                    case SqlErrorCode.ConnectionFailed:
                        //This is a very non-specific error, can happen for almost any reason
                        //so we can't make any conclusions from it
                        break;
                    case SqlErrorCode.DatabaseUnavailable:
                        ShouldRetryImmediately = false;
                        break;
                    case SqlErrorCode.EncryptionNotSupported:
                        //this error code is sometimes sent by the client when it shouldn't be
                        //Therefore we need to retry it, even though it seems this problem wouldn't fix itself
                        ShouldRetry = true;
                        ShouldRetryImmediately = true;
                        break;
                    case SqlErrorCode.DatabaseWorkerThreadThrottling:
                    case SqlErrorCode.ServerWorkerThreadThrottling:
                        ShouldRetry = true;
                        ShouldRetryImmediately = false;
                        break;
                    
                    
                    //The following errors are probably not going to resolved in 10 seconds
                    //They're mostly related to poor query design, broken DB configuration, or too much data
                    case SqlErrorCode.ExceededDatabaseSizeQuota:
                    case SqlErrorCode.TransactionRanTooLong:
                    case SqlErrorCode.TooManyLocks:
                    case SqlErrorCode.ExcessiveTempDBUsage:
                    case SqlErrorCode.ExcessiveMemoryUsage:
                    case SqlErrorCode.ExcessiveTransactionLogUsage:
                    case SqlErrorCode.BlockedByFirewall:
                    case SqlErrorCode.TooManyFirewallRules:
                    case SqlErrorCode.CannotOpenServer:
                    case SqlErrorCode.LoginFailed:
                    case SqlErrorCode.FeatureNotSupported:
                    case SqlErrorCode.StoredProcedureNotFound:
                    case SqlErrorCode.StringOrBinaryDataWouldBeTruncated:
                        this.ShouldRetry = false;
                        break;
                }
            }
            if (this.ShouldRetry && Errors.Count == 1)
            {
                SqlErrorCode code = this.Errors[0];
                if (code == SqlErrorCode.TransientServerError)
                {
                    this.ShouldRetryImmediately = true;
                }
            }
            
            if (IsResourceThrottled(ResourcesThrottled.Quota) ||
                IsResourceThrottled(ResourcesThrottled.Disabled))
            {
                this.ShouldRetry = false;
            }
            if (!this.ShouldRetry)
            {
                this.ShouldRetryImmediately = false;
            }
            SetThrottlingMessage();
        }
        private void SetThrottlingMessage()
        {
            if (OperationsThrottled == Sql.OperationsThrottled.None)
            {
                ThrottlingMessage = "No throttling";
            }
            else
            {
                string opsThrottled = OperationsThrottled.ToString();
                string seriousExceeded = SeriouslyExceededResources.ToString();
                string slightlyExceeded = SlightlyExceededResources.ToString();
                ThrottlingMessage = "SQL Server throttling encountered. Operations throttled: " + opsThrottled
                            + ", Resources Seriously Exceeded: " + seriousExceeded
                            + ", Resources Slightly Exceeded: " + slightlyExceeded;
            }
        }
        private bool IsResourceThrottled(ResourcesThrottled resource)
        {
            return ((this.SeriouslyExceededResources & resource) > 0 ||
                    (this.SlightlyExceededResources & resource) > 0);
        }
        private SqlErrorCode GetSqlErrorCodeFromInt(int p)
        {
            switch (p)
            {
                case 40014:
                case 40054:
                case 40133:
                case 40506:
                case 40507:
                case 40508:
                case 40512:
                case 40516:
                case 40520:
                case 40521:
                case 40522:
                case 40523:
                case 40524:
                case 40525:
                case 40526:
                case 40527:
                case 40528:
                case 40606:
                case 40607:
                case 40636:
                    return SqlErrorCode.FeatureNotSupported;
            }
            try
            {
                return (SqlErrorCode)p;
            }
            catch
            {
                return SqlErrorCode.Unknown;
            }
        }
        /// <summary>
        /// Parse out the reason code from a ServerBusy error. 
        /// </summary>
        /// <remarks>Basic idea extracted from http://msdn.microsoft.com/en-us/library/gg491230.aspx
        /// </remarks>
        /// <param name="error"></param>
        private void ParseServerBusyError(ISqlError error)
        {
            int idx = error.Message.LastIndexOf("Code:");
            if (idx < 0)
            {
                return;
            }
            string reasonCodeString = error.Message.Substring(idx + "Code:".Length);
            int reasonCode;
            if (!int.TryParse(reasonCodeString, out reasonCode))
            {
                return;
            }
            int opsThrottledInt = (reasonCode & 3);
            this.OperationsThrottled = (OperationsThrottled)(Math.Max((int)OperationsThrottled, opsThrottledInt));
            int slightResourcesMask = reasonCode >> 8;
            int seriousResourcesMask = reasonCode >> 16;
            foreach (ResourcesThrottled resourceType in Enum.GetValues(typeof(ResourcesThrottled)))
            {
                if ((seriousResourcesMask & (int)resourceType) > 0)
                {
                    this.SeriouslyExceededResources |= resourceType;
                }
                if ((slightResourcesMask & (int)resourceType) > 0)
                {
                    this.SlightlyExceededResources |= resourceType;
                }
            }
        }
    }
    public interface ISqlError
    {
        int Number { get; }
        string Message { get; }
    }
    public class SqlErrorWrapper : ISqlError
    {
        public SqlErrorWrapper(SqlError error)
        {
            this.Number = error.Number;
            this.Message = error.Message;
        }
        public SqlErrorWrapper()
        {
        }
        public int Number { get; set; }
        public string Message { get; set; }
    }
    /// <summary>
    /// Documents some of the ErrorCodes from SQL/SQL Azure. 
    /// I have not included all possible errors, only the ones I thought useful for modifying runtime behaviors
    /// </summary>
    /// <remarks>
    /// Comments come from: http://social.technet.microsoft.com/wiki/contents/articles/sql-azure-connection-management-in-sql-azure.aspx
    /// </remarks>
    public enum SqlErrorCode : int
    {
        /// <summary>
        /// We don't recognize the error code returned
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// A SQL feature/function used in the query is not supported. You must fix the query before it will work.
        /// This is a rollup of many more-specific SQL errors
        /// </summary>
        FeatureNotSupported = 1,
        /// <summary>
        /// Probable cause is server maintenance/upgrade. Retry connection immediately.
        /// </summary>
        TransientServerError = 40197,
        /// <summary>
        /// The server is throttling one or more resources. Reasons may be available from other properties
        /// </summary>
        ServerBusy = 40501,
        /// <summary>
        /// You have reached the per-database cap on worker threads. Investigate long running transactions and reduce server load. 
        /// http://social.technet.microsoft.com/wiki/contents/articles/1541.windows-azure-sql-database-connection-management.aspx#Throttling_Limits
        /// </summary>
        DatabaseWorkerThreadThrottling = 10928,
        /// <summary>
        /// The per-server worker thread cap has been reached. This may be partially due to load from other databases in a shared hosting environment (eg, SQL Azure).
        /// You may be able to alleviate the problem by reducing long running transactions.
        /// http://social.technet.microsoft.com/wiki/contents/articles/1541.windows-azure-sql-database-connection-management.aspx#Throttling_Limits
        /// </summary>
        ServerWorkerThreadThrottling = 10929,
        ExcessiveMemoryUsage = 40553,
        BlockedByFirewall = 40615,
        /// <summary>
        /// The database has reached the maximum size configured in SQL Azure
        /// </summary>
        ExceededDatabaseSizeQuota = 40544,
        /// <summary>
        /// A transaction ran for too long. This timeout seems to be 24 hours.
        /// </summary>
        /// <remarks>
        /// 24 hour limit taken from http://social.technet.microsoft.com/wiki/contents/articles/sql-azure-connection-management-in-sql-azure.aspx
        /// </remarks>
        TransactionRanTooLong = 40549,
        TooManyLocks = 40550,
        ExcessiveTempDBUsage = 40551,
        ExcessiveTransactionLogUsage = 40552,
        DatabaseUnavailable = 40613,
        CannotOpenServer = 40532,
        /// <summary>
        /// SQL Azure databases can have at most 128 firewall rules defined
        /// </summary>
        TooManyFirewallRules = 40611,
        /// <summary>
        /// Theoretically means the DB doesn't support encryption. However, this can be indicated incorrectly due to an error in the client library. 
        /// Therefore, even though this seems like an error that won't fix itself, it's actually a retryable error.
        /// </summary>
        /// <remarks>
        /// http://social.msdn.microsoft.com/Forums/en/ssdsgetstarted/thread/e7cbe094-5b55-4b4a-8975-162d899f1d52
        /// </remarks>
        EncryptionNotSupported = 20,
        /// <summary>
        /// User failed to connect to the database. This is probably not recoverable.
        /// </summary>
        /// <remarks>
        /// Some good info on more-specific debugging: http://blogs.msdn.com/b/sql_protocols/archive/2006/02/21/536201.aspx
        /// </remarks>
        LoginFailed = 18456,
        /// <summary>
        /// Failed to connect to the database. Could be due to configuration issues, network issues, bad login... hard to tell
        /// </summary>
        ConnectionFailed = 4060,
        /// <summary>
        /// Client tried to call a stored procedure that doesn't exist
        /// </summary>
        StoredProcedureNotFound = 2812,
        /// <summary>
        /// The data supplied is too large for the column
        /// </summary>
        StringOrBinaryDataWouldBeTruncated = 8152
    }
