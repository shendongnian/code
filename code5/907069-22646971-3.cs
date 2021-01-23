    [ServiceContract]
    public interface IExampleService
    {
    	[OperationContract]
    	Task<string> GetTestAsync(bool runSynchronously);
    }
