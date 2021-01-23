    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    
    namespace WcfService1
    {
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllCountries")]
            DTOCountry[] GetAllCountries();
        }
    
        [DataContract]
        public class DTOCountry
        {
            [DataMember]
            public string Name { get; set; }
        }
    }
