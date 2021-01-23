    [ServiceContract]
    public interface IWebProxyService
    {
        [OperationContract]
        [WebGet(UriTemplate="getData")]
        string GetSomeData();
    }
