    public namespace Project
    {
        [DataContract(Namespace = "http://someNameSpace")]
        public class Root
        {
            [DataMember]
            public string DisplayName { get; set; }
            [DataMember]
            public List<Group> Groups { get; set; }
        }
        
        [DataContract(Namespace = "http://someNameSpace")]
        public class Group : ISomeType
        {
            [DataMember]
            public List<ISomeType> Elements { get; set; }
        }
        
        [DataContract(Namespace = "http://someNameSpace")]
        public class SomeType : ISomeType
        {
            [DataMember]
            public string DisplayName { get; set; }
        }
        public interface ISomeType
        {
            string DisplayName { get; set; }
        }
    }
