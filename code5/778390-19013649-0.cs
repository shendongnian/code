    [ServiceContract]
    public interface VCIWCFService
    {
         [OperationContract]
         [WebGet(UriTemplate = "/{encodedParameters}")]
         string GetSomething();
    }
