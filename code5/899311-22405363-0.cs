    public sealed class MyException: Exception
    {
        public MyException(string message, string stackTrace): base(message)
        {
            _stackTrace = stackTrace;
        }
        public override string StackTrace
        {
            get
            {
                return _stackTrace;
            }
        }
        private readonly string _stackTrace;
    }
