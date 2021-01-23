    public class YourException : ApplicationException
        {
            public YourException () { }
    
            public YourException (string message) : base(message) { }
    
            public YourException (string message, Exception innerException) : base(message, innerException) { }
    
            public bool Logged { get; set; }
        }
