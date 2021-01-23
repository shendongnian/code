    public enum OperationType { DataInitialization, Authentication, Caching }
    
    public class Message 
    {
        public OperationType Operation { get; set; }
        public Task Task { get; set; }
    }
