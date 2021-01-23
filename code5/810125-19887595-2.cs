    namespace Common
    {
        using System.Collections.Generic;
        using System.Runtime.Serialization;
    
        [DataContract]
        public class Result
        {
            [DataMember]
            public List<string> Rsults { get; set; }
        }
    }
