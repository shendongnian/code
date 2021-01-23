    public class NewCustomException : BaseException, ISerializable
    {
        public NewException()
        {
            // Add implementation.
        }
        public NewException(string message)
        {
            // Add implementation.
        }
        public NewException(string message, Exception inner)
        {
            // Add implementation.
        }
    
        // This constructor is needed for serialization.
       protected NewException(SerializationInfo info, StreamingContext context)
       {
            // Add implementation.
       }
    }
