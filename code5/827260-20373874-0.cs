    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void DoWork();
    }
