    namespace SAME_NAMESPACE_AS_PROXY_CLASS
    {
        // This is needed since the web service must have the username and pwd passed in a custom SOAP header, apparently
        public partial class MyService : System.Web.Services.Protocols.SoapHttpClientProtocol
        {
            public Creds credHeader;  // will hold the creds that are passed in the SOAP Header
        }
        [XmlRoot(Namespace = "http://cnn.com/xy")]  // your service's namespace goes in quotes
        public class Creds : SoapHeader
        {
            public string Username;
            public string Password;
        }
    }
