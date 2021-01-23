    using System;
    using System.Runtime.Serialization;
    namespace YourNamespace
    {
        [Serializable]
        [DataContract]
        public class Data
        {
            [DataMember(Name = "Text"]
            public string Text{get;set;}
            [DataMember(Name = "Value"]
            public string Value{get;set;}
            [DataMember(Name = "Expanded"]
            public bool Expanded{get;set;}
            [DataMember(Name = "Items"]
            public Data[] Items{get;set;}
        }
    }
