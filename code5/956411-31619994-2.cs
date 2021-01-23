    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    
    namespace Server
    {
        public class Service : IService
        {
            public ReturnContract GetOffset()
            {
                return new ReturnContract { Offset = new DateTimeOffset(DateTime.Now) };
            }
        }
    
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            ReturnContract GetOffset();
        }
    
        [DataContract]
        [KnownType(typeof(DateTimeOffset))]
        public class ReturnContract
        {
            [DataMember]
            public DateTimeOffset? Offset { get; set; }
        }
    }
