    [ServiceContract(SessionMode = SessionMode.Required,
        CallbackContract = typeof(INotifyMeDataUpdate))]
    public interface IService
    {
        [OperationContract(IsInitiating=true)]
        void Register();
        [OperationContract(IsTerminating= true)]
        void Unregister();
        [OperationContract(IsOneWay=true)]
        void Message(string theMessage);
    }
    public interface INotifyMeDataUpdate
    {
        [OperationContract(IsOneWay=true)]
        void GetUpdateNotification(string updatedData);
    }
