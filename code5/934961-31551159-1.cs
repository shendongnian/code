    using System.Runtime.Serialization;
    
    namespace FooBar
    {
        [DataContract]
        public class Foo
        {
            // Warning about type conflict.
            [DataMember]
            public string Bar { get; set; }
        }
    }
