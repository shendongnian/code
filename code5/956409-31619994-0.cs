    using System;
    using System.ServiceModel;
    
    namespace Server
    {
        public class Service : IService
        {
            public DateTimeOffset GetOffset()
            {
                return new DateTimeOffset(DateTime.Now);
            }
        }
    
        [ServiceContract]
        [ServiceKnownType(typeof(DateTimeOffset))]
        public interface IService
        {
            [OperationContract]
            DateTimeOffset GetOffset();
        }
    }
