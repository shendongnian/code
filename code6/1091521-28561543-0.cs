    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    
    namespace WcfKnownTypeStackOverFlow
    {
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            ResponseDTO GetDataFromWebService(RequestDTO request);
        }
    
        [DataContract]
        [KnownType(typeof(AddressDTO))]
        public class ResponseDTO
        {
            [DataMember]
            public string ID { get; set; }
        }
    
        [DataContract]
        public class AddressDTO : ResponseDTO
        {
            [DataMember]
            public List<Address> Elements { get; set; }
        }
    
        [DataContract]
        public class Address
        {
            [DataMember]
            public string Street { get; set; }
    
            [DataMember]
            public string City { get; set; }
        }
    
        [DataContract]
        public enum RequestDTO
        {
            [EnumMember]
            Request1,
    
            [EnumMember]
            Request2
        }
    }
