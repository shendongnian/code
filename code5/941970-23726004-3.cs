    [Serializable]
    public class RijException : Exception
    {
        public RijException(string message) : base(message)
        {
        }
        public RijException(string message, Exception inner) : base(message, inner)
        {
        }
        //serialization constructor
        protected RijException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
