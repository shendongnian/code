    [DataContract]
    public class MyRequest
    {
        [DataMember]
        public string myString { get; set; }
        [DataMember]
        public IEnumerable<string> myList { get; set; }
    }
