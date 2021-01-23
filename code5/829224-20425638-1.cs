    public class Try<TResult>
    {
        private readonly bool failure;
        private readonly TResult result;
        private readonly Exception exception;
        protected Try(TResult result)
        {
            this.result = result;
        }
        protected Try(Exception ex)
        {
            this.exception = ex;
            this.failure = true;
        }
        public TResult Result { get { return this.result; } }
        public Exception Exception { get { this.exception; } }
        public bool Failure { get { this.failure; } }
        public static Invoke(Func<TResult> action)
        {
            TResult result;
            try
            {
                result = action();
                return new Try(result);
            }
            catch (Exception ex)
            {
                return new Try(ex);
            }
        }
    }
