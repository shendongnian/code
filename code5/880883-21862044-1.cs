    [Serializable]
    public class TheAuthorOfThisMethodScrewedUpException : InvalidOperationException
    {
        private const string DefaultMessage = "The author of this method screwed up!";
        public TheAuthorOfThisMethodScrewedUpException()
            : this(DefaultMessage, null)
        { }
        public TheAuthorOfThisMethodScrewedUpException(Exception inner)
            : base(DefaultMessage, inner)
        { }
        public TheAuthorOfThisMethodScrewedUpException(string message)
            : this(message, null)
        { }
        public TheAuthorOfThisMethodScrewedUpException(string message, Exception inner)
            : base(message, inner)
        { }
        protected TheAuthorOfThisMethodScrewedUpException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
    
