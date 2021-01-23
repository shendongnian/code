    [DataContract]
    class User
    {
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public MyClass MyMember { get; set; }
    }
