    public sealed class Attempt<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attempt{T}"/> class.
        /// </summary>
        public Attempt() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Attempt{T}"/> class.
        /// </summary>
        public Attempt(Exception exception)
        {
            this.Exception = exception;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Attempt{T}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public Attempt(T result)
        {
            this.Result = result;
            this.HasResult = true;
        }
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        public T Result { get; private set; }
        /// <summary>
        /// Determines whether this instance has result.
        /// </summary>
        /// <returns><c>true</c> if this instance has result; otherwise, <c>false</c>.</returns>
        public bool HasResult { get; private set; }
        /// <summary>
        /// Returns the result with a true or false depending on whether its empty, but throws if there is an exception in the attempt.
        /// </summary>
        /// <param name="result">The result, which may be null.</param>
        /// <returns><c>true</c> if the specified result has a value; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.AggregateException">The attempt resulted in an exception. See InnerExceptions.</exception>
        public bool TryResult(out T result)
        {
            if (this.HasResult)
            {
                result = this.Result;
                return true;
            }
            else
            {
                if (this.Exception != null)
                {
                    throw new AggregateException("The attempt resulted in an exception. See InnerExceptions.", this.Exception);
                }
                else
                {
                    result = default(T);
                    return false;
                }
            }
        }
        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; private set; }
    }
