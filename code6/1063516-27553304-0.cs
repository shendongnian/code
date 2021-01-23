    [ServiceContract]
    public interface IMyService 
    {
        [OperationContract]
        string GetData();
    }
    
    public class MyService : IMyService 
    {
        public string GetData() { ... }
        private string ComputeData() { ... } // this one is not visible to clients
    }
