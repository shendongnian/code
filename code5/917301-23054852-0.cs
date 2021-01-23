    //Server interface
    [ServiceContract(CallbackContract = typeof(IGUIService))]
    public interface IServerService
    {
        [OperationContract(IsOneWay = true)]
        void Subscribe();
        [OperationContract(IsOneWay = true)]
        void Unsubscribe();
        ...
    }
    //Client interface
    [ServiceContract]
    public interface IGUIService
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string Message);
    }
