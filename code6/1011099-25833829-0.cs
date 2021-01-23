     [DataContract]
        public class RequestObject
        {
            [DataMember]
            public string someKey { get; set; }
            [DataMember]
           public List<List<StringData>> dataArrays{ get; set; }
        }
