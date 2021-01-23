    [ServiceContract(Namespace="", SessionMode=SessionMode.NotAllowed)]
    public interface IPrototype
    {
        [OperationContract(Action = "auth")]
        [XmlSerializerFormat]
        authResponse auth(authRequest auth);
    }
    [MessageContract(IsWrapped = false)]
    public class authRequest
    {
        [MessageBodyMember]
        public authRequestBody auth { get; set; }
    }
    [MessageContract(IsWrapped = true, WrapperName = "auth")]
    public class authRequestBody 
    {
        [XmlAttribute(AttributeName = "message-id"), MessageBodyMember]
        public int messageId { get; set; }
        [MessageBodyMember]
        public Login login { get; set; }
    }
    [MessageContract]
    public class Login 
    {
        [MessageBodyMember]
        public string userName { get; set; }
        
        [MessageBodyMember]
        public string Password { get; set; }
        
    }
