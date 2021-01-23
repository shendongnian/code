    namespace Foo
    {
        [ServiceContract(Namespace="http://kennyw.com/WCFservices/")]
        [WebService(Namespace="http://kennyw.com/sampleservices/")]
        public class MyService : System.Web.Services.WebService
        { 
            [WebMethod]
            [OperationContract]
            public string Hello(string name)
            { 
                return string.Format(“Hello {0}.”, name);
    
            }
        }
    }
