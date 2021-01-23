    [ServiceContract]
    public interface IExampleService
    {
    	[OperationContract]
    	string GetTest(bool runSynchronously);
    }
