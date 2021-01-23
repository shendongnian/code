    [ServiceContract]
    public interface IExampleService
    {
    	[OperationContract(Name = "GetTest")]
    	string GetTest();
    
    	[OperationContract(Name = "GetTestAsync")]
    	Task<string> GetTestAsync();
    
    	[OperationContract(Name = "GetTestRealAsync")]
    	Task<string> GetTestRealAsync();
    }
