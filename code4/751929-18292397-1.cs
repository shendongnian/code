    [ServiceContract]
    public interface INewProvider : IProvider
    {
 
        [OperationContract]
        double MyApiCall_3();
    }
