    [ServiceContract(CallbackContract = typeof(IMyCallBack))]
    public interface IMyService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void OnMessage(System.ServiceModel.Channels.Message msg);
    }
    [ServiceContract]
    interface IMyCallBack
    {
        [OperationContract(IsOneWay = true, Action="*")]
        void Reply(System.ServiceModel.Channels.Message msg);
    }
