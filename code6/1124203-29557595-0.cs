    public class Result<T>
    {
        public static Result<T> Success(T value)
        {
            return new Result<T>(value, true);
        }
        public static Result<T> Failure()
        {
            return new Result<T>(default(T), false);
        }
        
        private Result(T value, bool succeeded)
        {
            _value        = value;
            _succeeded = succeeded;
        }
        public T Value
        {
            get
            {
                // Don't call this on failure!
                Trace.Assert(_succeeded);
                return _value;
            }
        }
        public bool Succeeded
        {
            get
            {
                return _succeeded;
            }
        }
        private readonly T    _value;
        private readonly bool _succeeded;
    }
