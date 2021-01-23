    [ServiceContract]
    public interface ICollectorService
    {
       [OperationContract]
       [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, 
       BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Authenticate/{agentcode}/{pin}/{deviceIMEI}/{gpslat}/{gpslong}")]
        Authentification Authenticate(string agentcode,string pin, string deviceIMEI, string gpslat, string gpslong);
    }
