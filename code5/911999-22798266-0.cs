    [ServiceContract(CallbackContract=typeof(IKeepAliveEvents))]
    public interface IKeepAlive
    {
        [OperationContract(IsOneWay = true)]
        public void Ping();
    }
