System.Web.Services.Protocols.HttpWebClientProtocol
This has properties that you are looking for like ConnectionGroupName, Container etc
    public class Service1 : System.Web.Services.Protocols.HttpWebClientProtocol
    {
    
    }
insted of: **System.Web.Services.WebService** 
    public class Service1 : System.Web.Services.WebService
    {
    }
Reference: [MSDN][1]
  [1]: http://msdn.microsoft.com/en-us/library/System.Web.Services.Protocols.WebClientProtocol(v=vs.110).aspx
