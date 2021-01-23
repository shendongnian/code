    [XmlRoot(ElementName = "request", Namespace = "", IsNullable = false)]
    public class Request
    {
        [XmlAttributeAttribute(AttributeName = "id", Namespace = "")]
        public string Id { get; set; }
        [XmlElement("login", Type = typeof(LoginRequestData))]
        [XmlElement("logout", Type = typeof(LogoutRequestData))]
        public BaseRequestData RequestData { get; set; }
        public TRequestData GetRequestData<TRequestData>() where TRequestData : BaseRequestData
        {
            return RequestData as TRequestData;
        }
    }
    public abstract class BaseRequestData
    {
    }
    public class LoginRequestData : BaseRequestData
    {
        [XmlElementAttribute(ElementName = "username", Namespace = "")]
        public string Username;
        [XmlElementAttribute(ElementName = "password", Namespace = "")]
        public string Password;
    }
    public class LogoutRequestData : BaseRequestData
    {
    }
    public class SomeUnknownRequestData : BaseRequestData
    {
    }
