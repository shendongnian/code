    public class ExecutionResult
    {
        public ExecutionResult() : this(null)
        {
        }
        public ExecutionResult(ExecutionResult result)
        {
            if (result != null)
            {
                Success = result.Success;
                Errors = new List<ErrorInfo>(result.Errors);
            }
            else
            {
                Errors = new List<ErrorInfo>();
            }
        }
        private bool? _success;
        public bool Success
        {
            get { return _success ?? Errors.Count == 0; }
            set { _success = value; }
        }
        public IList<ErrorInfo> Errors { get; private set; }
    }
    /*T is for result (any business object)*/
    public class ExecutionResult<T> : ExecutionResult
    {
        public ExecutionResult() : this(null)
        {
        }
        public ExecutionResult(T result) : this(null)
        {
            Value = result;
        }
        public ExecutionResult(ExecutionResult result)
            : base(result)
        {
            var r = result as ExecutionResult<T>;
            if (r != null)
            {
                Value = r.Value;
            }
        }
        public T Value { get; set; }
    }
