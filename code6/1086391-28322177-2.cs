    class JOVALException : Exception
    {
        public JOVALException(string errorCode, Exception innerException)
            : base(errorCode, innerException)
        {
        }
    }
