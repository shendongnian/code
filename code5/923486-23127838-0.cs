    [ServiceContract]
    public interface ICoolerService
    {
         [OperationContract]
         IEnumerable<Cooler> Get(IEnumerable<int> ids);
    
         [OperationContract]
         IEnumerable<Cooler> Get(IEnumerable<CoolerRequest> req);
    }
