    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    namespace WcfService1
    {   
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebGet(RequestFormat = WebMessageFormat.XML, ResponseFormat = WebMessageFormat.XML, UriTemplate = "/display/")]
            string Display();        
        }    
    }
