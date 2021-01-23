    [Serializable]
    public class NewException : Exception
    {
        public NewException() : base("Default message for this type") { }
        public NewException(string message) : base(message) { }
        public NewException(string message, Exception inner) : base(message, inner) { }
    
        // This constructor is needed for serialization.
       protected NewException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
    }
