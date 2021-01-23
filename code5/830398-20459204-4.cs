    [ServiceContract(Name = "MyServiceClass", Namespace = "Ian.Server")]
    public interface IClientWcfService
    {
        [OperationContract(AsyncPattern = true, Action = "Ian.Server/MyServiceClass/CreateParentData",
            ReplyAction = "Ian.Server/MyServiceClass/CreateParentDataResponse")]
        IAsyncResult BeginCreateParentData(ClientWcfServiceStartUpMode mode, AsyncCallback callback, object asyncState);
        
        ClientWcfServiceParentData EndCreateParentData(IAsyncResult result);
    }
    public interface IClientWcfServiceChannel : IClientWcfService, IClientChannel
    {
    }
    [DataContract(Name = "ServiceChildData", Namespace = "Ian.Server")]
    public class ClientWcfServiceParentData
    {
        [DataMember]
        public IEnumerable<ClientWcfServiceChildData> Children { get; set; }
    }
    [DataContract(Name = "ServiceChildData", Namespace = "Ian.Server")]
    public class ClientWcfServiceChildData
    {
        [DataMember]
        public string ChildName { get; set; }
        [DataMember]
        public ClientWcfServiceChildData NestedChild { get; set; }
        [DataMember]
        public string Text { get; set; }
    }
    [DataContract(Name = "ServiceStartUpMode", Namespace = "Ian.Server")]
    public enum ClientWcfServiceStartUpMode
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "StartUpNow")]
        StartUpNow,
        [EnumMember(Value = "StartUpLater")]
        StartUpLater
    }
