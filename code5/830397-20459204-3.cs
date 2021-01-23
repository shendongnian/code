    [ServiceContract(Name = "MyServiceClass", Namespace = "Ian.Server")]
    public interface IServerWcfService
    {
        [OperationContract]
        ServerWcfServiceParentData CreateParentData(ServerWcfServiceStartUpMode mode);
    }
    [DataContract(Name = "ServiceChildData", Namespace = "Ian.Server")]
    public class ServerWcfServiceParentData
    {
        [DataMember]
        public IEnumerable<ServerWcfServiceChildData> Children { get; private set; }
    }
    [DataContract(Name = "ServiceChildData", Namespace = "Ian.Server")]
    public class ServerWcfServiceChildData
    {
        [DataMember]
        public string ChildName { get; set; }
        [DataMember]
        public ServerWcfServiceChildData NestedChild { get; set; }
        [DataMember]
        public string Text { get; set; }
    }
    [DataContract(Name = "ServiceStartUpMode", Namespace = "Ian.Server")]
    public enum ServerWcfServiceStartUpMode
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "StartUpNow")]
        StartUpNow,
        [EnumMember(Value = "StartUpLater")]
        StartUpLater
    }
