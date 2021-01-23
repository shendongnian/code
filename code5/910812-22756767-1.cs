    namespace Test1
    {
        [DataContract]
        public sealed class Demo
        {
            [DataMember]
            public string Value { get; set; }
        }
    }
    namespace Test2
    {
        // Note the namespace includes both nested namespaces, i.e. ConsoleApp1.Test1
        [DataContract(Namespace="http://schemas.datacontract.org/2004/07/ConsoleApp1.Test1")]
        public sealed class Demo
        {
            [DataMember]
            public string Value { get; set; }
        }
    }
