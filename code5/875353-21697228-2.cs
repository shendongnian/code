    public class MyValidationException : Exception
    {
        public MyValidationException(string message)
            : base(message)
        {
        }
    
        // A custom exceptions needs several constructors, so add them also
    }
