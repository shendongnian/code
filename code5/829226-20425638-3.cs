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
        public static Try<TResult> Invoke(Func<TResult> func)
        {
            TResult result;
            try
            {
                result = func();
                return new Try(result);
            }
            catch (Exception ex)
            {
                return new Try(ex);
            }
        }
        public static IEnumerable<Try<TResult>> Invoke(
                IEnumerable<Func<TResult>> funcs)
        {
            return funcs.Select(Invoke);
        }
    }
