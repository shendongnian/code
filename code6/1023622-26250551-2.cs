    [Serializable]
    public class CustomException : Exception
    {
        public CustomException()
            : base() { }
        
        public CustomException(string message)
            : base(message) { }
        
        public CustomException(string format, params object[] args)
            : base(string.Format(format, args)) { }
        
        public CustomException(string message, Exception innerException)
            : base(message, innerException) { }
        
        public CustomException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
        
        protected CustomException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
        // Added a custom constructor to allow adding the custom properties:
        internal CustomException(string message, Exception innerException, string property1, string property2, string property3) 
            : base(message, innerException) { }
        {
            Property1 = property1;
            Property2 = property2;
            Property3 = property3;        
        }
        // 3 properties holding all the values of the properties passed to it.
        public string Property1 { get; protected set; }
        public string Property2 { get; protected set; }
        public string Property3 { get; protected set; }
        // Override the message to allow custom exception message to be passed to Elmah.
        public override string Message
        {
            get
            {
                return string.Format("Error logging to db using Property1 = {0}, Property2 = {1} and     Property3 = {2}", Property1, Property2, Property3);
            }
        }
    }
