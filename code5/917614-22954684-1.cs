    [DataContract]
    public class Order
    {
        [DataMember]
        public string personId {get; set;}
        [DataMember]
        public int locationId {get; set;}
        [DataMember]
        public string order {get; set;}
    }
