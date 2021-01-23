    public class OperationParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    
    public class OperationCaller
    {
        public string UserPrincipalName { get; set; }
        public string ClientIPAddress { get; set; }
    }
    
    public class OperationRequest
    {
        public string Method { get; set; }
        public string Url { get; set; }
    }
    
    public class Operation
    {
        public string OperationId { get; set; }
        public string OperationObjectId { get; set; }
        public string OperationName { get; set; }
        public List<OperationParameter> OperationParameters { get; set; }
        public OperationCaller OperationCaller { get; set; }
        public string OperationResult { get; set; }
        public int OperationStatus { get; set; }
        public OperationRequest OperationRequest { get; set; }
        public string OperationStartedTime { get; set; }
        public string OperationCompletedTime { get; set; }
    }
    
    public class RootObject
    {
        public List<Operation> Operations { get; set; }
        public object ContinuationToken { get; set; }
    }
