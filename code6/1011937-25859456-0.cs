    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    
    namespace WcfService1
    {
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            [WebGet(UriTemplate = "sayhello")]
            Stream SayHello();
        }
    }
