    class ExceptionEventArgs : EventArgs
    {
        public enum ExceptionLevel
        {
            Debug,
            Info,
            Error
        }
        public ExceptionLevel ExceptionType { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
    class SharePointEventArgs : ExceptionEventArgs { ... }
    class FTPEventArgs : ExceptionEventArgs { ... }
