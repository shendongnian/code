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
        [ServiceContract]
        public interface IService2
        {
            [OperationContract]
            DTOCountry[] GetAllCountries2();
        }
        [DataContract]
        public class DTOCountry
        {
            [DataMember]
            public string Name { get; set; }
        }
    }
