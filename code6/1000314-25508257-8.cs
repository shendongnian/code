	// class for the root object:
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
    // class for the address object:
    [DataContract]
    {
    	[DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
    }
