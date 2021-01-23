    [DataMember]
    public class Order
    {
        [DataContract]
        public string personId {get; set;}
        [DataContract]
        public int locationId {get; set;}
        [DataContract]
        public string order {get; set;}
    }
