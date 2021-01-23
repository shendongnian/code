    [CollectionDataContract(Namespace = "")]
    public class StringList : List<string>
    {
        public StringList() { }
        public StringList(IEnumerable<string> items) : base(items) { }
    }
    [DataContract(Namespace = "")]
    public class User
    {
        [DataMember(Order = 0)]
        public string UserName { get; set; }  //ro
        [DataMember(Order = 1)]
        public int CustomerID { get; set; } //ro
        [DataMember(Order = 2)]
        public string Email { get; set; }
        [DataMember(Order = 3)]
        public string Phone { get; set; }
        [DataMember(Order = 4)]
        public string Mobile { get; set; }
        [DataMember(Order = 5)]
        public string FullName { get; set; }
        [DataMember(Order = 6)]
        public StringList Roles { get; set; }
        [DataMember(Order = 7)]
        public string Culture { get; set; }
        [DataMember(Order = 8)]
        public string Language { get; set; }
        [DataMember(Order = 9)]
        public string TimeZone { get; set; }
        [DataMember(Order = 10)]
        public DateTime Created { get; set; } //ro
    }
