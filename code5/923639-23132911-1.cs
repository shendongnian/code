    public class YourException : ApplicationException
        {
            public YourException () { }
    
            public YourException (string message) : base(message) { }
    
            public YourException (string message, Exception innerException) : base(message, innerException) { }
    
            public bool LoggedInLogFile { get; set; }
            public bool LoggedInDataBase { get; set; }
        }
