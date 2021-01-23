    class OperationResult
    {
        public OperationStatus Status { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
        // or list of exceptions
    }
    
    class LoginOperationResult : OperationResult
    {
        // Login result specific data.
    }
    enum OperationStatus
    {
        Success,
        Denied,
        ValidationFailed,
        // etc.
    }
