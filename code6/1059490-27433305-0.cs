    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/MyNamespace")]
    public class Location
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Collection<int> DataSourceIds { get; set; }
    }
