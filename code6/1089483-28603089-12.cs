    public class BusinessException : Exception, ISerializable
    {
        public BusinessException(string message)
            : base(message)
        {
            // Add implemenation (if required)
        }
    }
