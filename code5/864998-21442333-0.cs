    [ServiceContract(Namespace = "http://tempura.org/ISubscribe")]
    public interface IUpdate
    {
        [OperationContract(IsOneWay = true)]
        void OnUpdate(string update);
        [OperationContract(IsOneWay = true)]
        void OnSubscriptionLost(FaultException exception);
    }
