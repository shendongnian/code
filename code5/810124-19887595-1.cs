    namespace Common
    {
        using System.Runtime.Serialization;
    
        [DataContract]
        public class CustomRequest
        {
            [DataMember]
            public int MyValue { get; set; }
        }
    }
