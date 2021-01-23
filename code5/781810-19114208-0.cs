    public class QueryContinueEventArgs : EventArgs
    {
        public QueryContinueEventArgs(string failedFile, Exeption failure)
        {
            FailedFile = failedFile;
            Failure = failure;
            Continue = false;
        }
        public string FailedFile { get; private set; }
        public Exception Failure { get; private set; }
        public Continue { get; set; }
    }
    public event EventHandler<QueryContinueEventArgs> QueryContinueAfterCopyFailure;
