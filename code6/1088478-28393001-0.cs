    [ServiceContract(Namespace="", SessionMode=SessionMode.NotAllowed)]
    public interface IPrototype
    {
        [OperationContract(Action="auth")]
        string Auth(AuthRequest authRequest);
    }
    [MessageContract(IsWrapped = false)] // notice the unwrapping
    public class AuthRequest
    {
        [XmlAttribute]
        public int message-id { get; set; }
        [XmlElement]
        public Login Login { get; set; }
    }
    [MessageContract]
    public class Login 
    {
        [XmlElement]
        public string userName { get; set; }
        [XmlElement]
        public string Password { get; set; }
    }
