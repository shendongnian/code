    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IHelloService
    {
        [OperationContract]
        string SayHello();
    }
