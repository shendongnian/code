    /// <summary>
    /// Encapsulates the return value from a method that has a value, error status and optional error message.
    /// This is to be used in cases where a method call can fail, but you don't want to throw an exception;
    /// for example, because you have an error message string that you want to be displayed to the user.
    /// </summary>
    /// <typeparam name="T">The type of the main return value.</typeparam>
    
    [DataContract]
    public class Result<T>
    {
        /// <summary>Creates a failure result without an error message or an exception.</summary>
        /// <returns>A failure result value.</returns>
        public static Result<T> Failure()
        {
            return new Result<T>(default(T), false, string.Empty, null, false);
        }
        /// <summary>Creates a failure result with an error message but no exception.</summary>
        /// <param name="errorMessage">
        /// The optional error message. This may not be null. 
        /// It may however be <see cref="String.Empty"/>.
        /// </param>
        /// <returns>A failure result value.</returns>
        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(default(T), false, errorMessage, null, false);
        }
        /// <summary>Creates a failure result with an exception but no error message.</summary>
        /// <param name="exception">The exception. This may be null.</param>
        /// <returns>A failure result value.</returns>
        public static Result<T> Failure(Exception exception)
        {
            return new Result<T>(default(T), false, string.Empty, exception, false);
        }
        /// <summary>Creates a failure result with an error message and an exception.</summary>
        /// <param name="errorMessage">
        /// The optional error message. This may not be null.
        /// It may however be <see cref="String.Empty"/>.
        /// </param>
        /// <param name="exception">The exception. This may be null.</param>
        /// <returns>A failure result value.</returns>
        public static Result<T> Failure(string errorMessage, Exception exception)
        {
            return new Result<T>(default(T), false, errorMessage, exception, false);
        }
        /// <summary>Creates a failure result without an error message or an exception.</summary>
        /// <param name="value">The result value.</param>
        /// <returns>A failure result value.</returns>
        public static Result<T> Failure(T value)
        {
            return new Result<T>(value, false, string.Empty, null, true);
        }
        /// <summary>Creates a failure result with an error message but no exception.</summary>
        /// <param name="errorMessage">
        /// The optional error message. This may not be null. 
        /// It may however be <see cref="String.Empty"/>.
        /// </param>
        /// <param name="value">The result value.</param>
        /// <returns>A failure result value.</returns>
        public static Result<T> Failure(string errorMessage, T value)
        {
            return new Result<T>(value, false, errorMessage, null, true);
        }
        /// <summary>Creates a failure result with an exception but no error message.</summary>
        /// <param name="exception">The exception. This may be null.</param>
        /// <param name="value">The result value.</param>
        /// <returns>A failure result value.</returns>
        public static Result<T> Failure(Exception exception, T value)
        {
            return new Result<T>(value, false, string.Empty, exception, true);
        }
        /// <summary>Creates a failure result with an error message and an exception.</summary>
        /// <param name="errorMessage">
        /// The optional error message. This may not be null.
        /// It may however be <see cref="String.Empty"/>.
        /// </param>
        /// <param name="exception">The exception. This may be null.</param>
        /// <param name="value">The result value.</param>
        /// <returns>A failure result value.</returns>
        public static Result<T> Failure(string errorMessage, Exception exception, T value)
        {
            return new Result<T>(value, false, errorMessage, exception, true);
        }
        /// <summary>Creates a success result.</summary>
        /// <param name="value">The successful value.</param>
        /// <returns>A success result value.</returns>
        public static Result<T> Success(T value)
        {
            return new Result<T>(value, true, string.Empty, null, true);
        }
        /// <summary>
        /// The error message, if applicable and if <see cref="IsSuccessful"/> is false.
        /// This cannot be null, but it may be <see cref="String.Empty"/>.
        /// This is meaningless if <see cref="IsSuccessful"/> is true.
        /// Do not call this if <see cref="IsSuccessful"/> is true.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if this is called when <see cref="IsSuccessful"/> is true.
        /// </exception>
        public string ErrorMessage
        {
            get
            {
                if (IsSuccessful)
                {
                    throw new InvalidOperationException("You cannot access the error message if the method call was successful.");
                }
                return _errorMessage;
            }
        }
        /// <summary>
        /// The primary return value from the method. 
        /// This is meaningless if <see cref="HasValue"/> is false.
        /// Do not call this if <see cref="HasValue"/> is false.
        /// (If <see cref="IsSuccessful"/> is true, then <see cref="HasValue"/> will also be true.)
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if this is called when <see cref="HasValue"/> is false.
        /// </exception>
        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("You cannot access the result value if the method call failed and did not set a result value.");
                }
                return _value;
            }
        }
        /// <summary>
        /// Does the result have a valid value?
        /// If <see cref="IsSuccessful"/> is true then this will also be true.
        /// A result cannot be successful without having an associated valid result value.
        /// </summary>
        public bool HasValue
        {
            get
            {
                return _hasValue;
            }
        }
        /// <summary>
        /// Was the method call successful?
        /// If this is true, then <see cref="HasValue"/> will also be true. 
        /// A result cannot be successful without having an associated valid result value.
        /// </summary>
        public bool IsSuccessful
        {
            get
            {
                return _isSuccessful;
            }
        }
        /// <summary>
        /// The optional <see cref="Exception"/> associated with a failure, if applicable.
        /// This may be null.
        /// Do not call this if <see cref="IsSuccessful"/> is true.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if this is called when <see cref="IsSuccessful"/> is true.
        /// </exception>
        public Exception Exception
        {
            get
            {
                if (IsSuccessful)
                {
                    throw new InvalidOperationException("You cannot access the exception if the method call was successful.");
                }
                return _exception;
            }
        }
        
        /// <summary>Constructor.</summary>
        /// <param name="value">T</param>
        /// <param name="isSuccessful">Was the method call successful?</param>
        /// <param name="errorMessage">The optional error message. This may not be null.
        /// It must be <see cref="string.Empty"/> if <paramref name="isSuccessful"/> is true.</param>
        /// <param name="exception">The exception, if applicable. Must be null if <paramref name="isSuccessful"/> is true.</param>
        /// <param name="isValueValid">Is <paramref name="value"/> valid?</param>
        private Result(T value, bool isSuccessful, string errorMessage, Exception exception, bool isValueValid)
        {
            if (errorMessage == null)
            {
                throw new ArgumentNullException("errorMessage");
            }
            if (isSuccessful && !string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentOutOfRangeException("errorMessage", errorMessage, "errorMessage must be empty if isSuccessful is true.");
            }
            if (isSuccessful && (exception != null))
            {
                throw new ArgumentOutOfRangeException("exception", exception, "exception must be null if isSuccessful is true.");
            }
            _value        = value;
            _exception    = exception;
            _isSuccessful = isSuccessful;
            _hasValue     = isValueValid;
            _errorMessage = errorMessage;
        }
        [DataMember] private readonly T         _value;
        [DataMember] private readonly string    _errorMessage;
        [DataMember] private readonly bool      _isSuccessful;
        [DataMember] private readonly bool      _hasValue;
        [DataMember] private readonly Exception _exception;
    }
    /// <summary>
    /// Encapsulates the return value from a method that has an error status and optional error message, 
    /// but no actual return value.
    /// This is to be used in cases where a method call can fail, but you don't want to throw an exception;
    /// for example, because you have an error message string that you want to be displayed to the user.
    /// </summary>
    [DataContract]
    public class Result
    {
        /// <summary>Creates a failure result without an error message or an exception.</summary>
        /// <returns>A failure result value.</returns>
        public static Result Failure()
        {
            return new Result(false, string.Empty, null);
        }
        /// <summary>Creates a failure result with an error message but no exception.</summary>
        /// <param name="errorMessage">
        /// The optional error message. This may not be null. 
        /// It may however be <see cref="String.Empty"/>.
        /// </param>
        /// <returns>A failure result value.</returns>
        public static Result Failure(string errorMessage)
        {
            return new Result(false, errorMessage, null);
        }
        /// <summary>Creates a failure result with an exception but no error message.</summary>
        /// <param name="exception">The exception. This may be null.</param>
        /// <returns>A failure result value.</returns>
        public static Result Failure(Exception exception)
        {
            return new Result(false, string.Empty, exception);
        }
        /// <summary>Creates a failure result with an error message and an exception.</summary>
        /// <param name="errorMessage">
        /// The optional error message. This may not be null.
        /// It may however be <see cref="String.Empty"/>.
        /// </param>
        /// <param name="exception">The exception. This may be null.</param>
        /// <returns>A failure result value.</returns>
        public static Result Failure(string errorMessage, Exception exception)
        {
            return new Result(false, errorMessage, exception);
        }
        /// <summary>Creates a success result.</summary>
        /// <returns>A success result value.</returns>
        public static Result Success()
        {
            return new Result(true, string.Empty, null);
        }
        /// <summary>
        /// The error message, if applicable and if <see cref="IsSuccessful"/> is false.
        /// This cannot be null, but it may be <see cref="String.Empty"/>.
        /// This is meaningless if <see cref="IsSuccessful"/> is true.
        /// Do not call this if <see cref="IsSuccessful"/> is true.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if this is called when <see cref="IsSuccessful"/> is true.
        /// </exception>
        public string ErrorMessage
        {
            get
            {
                if (IsSuccessful)
                {
                    throw new InvalidOperationException("You cannot access the error message if the method call was successful.");
                }
                return _errorMessage;
            }
        }
        /// <summary>Was the method call successful?</summary>
        public bool IsSuccessful
        {
            get
            {
                return _isSuccessful;
            }
        }
        /// <summary>
        /// The optional <see cref="Exception"/> associated with a failure, if applicable.
        /// This may be null.
        /// Do not call this if <see cref="IsSuccessful"/> is true.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if this is called when <see cref="IsSuccessful"/> is true.
        /// </exception>
        public Exception Exception
        {
            get
            {
                if (IsSuccessful)
                {
                    throw new InvalidOperationException("You cannot access the exception if the method call was successful.");
                }
                return _exception;
            }
        }
        /// <summary>Constructor.</summary>
        /// <param name="isSuccessful">Was the method call successful?</param>
        /// <param name="errorMessage">The optional error message. This may not be null.
        /// It must be <see cref="string.Empty"/> if <paramref name="isSuccessful"/> is true.</param>
        /// <param name="exception">The exception, if applicable. Must be null if <paramref name="isSuccessful"/> is true.</param>
        private Result(bool isSuccessful, string errorMessage, Exception exception)
        {
            if (errorMessage == null)
            {
                throw new ArgumentNullException("errorMessage");
            }
            if (isSuccessful && !string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentOutOfRangeException("errorMessage", errorMessage, "errorMessage must be empty if isSuccessful is true.");
            }
            if (isSuccessful && (exception != null))
            {
                throw new ArgumentOutOfRangeException("exception", exception, "exception must be null if isSuccessful is true.");
            }
            _exception    = exception;
            _isSuccessful = isSuccessful;
            _errorMessage = errorMessage;
        }
        [DataMember] private readonly string    _errorMessage;
        [DataMember] private readonly bool      _isSuccessful;
        [DataMember] private readonly Exception _exception;
    }
