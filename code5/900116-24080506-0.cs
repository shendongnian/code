    [DataContract]
    public class CustomMergeVar : MergeVar
    {
        [DataMember(Name = "FNAME")]
        public string FirstName { get; set; }
        [DataMember(Name = "LNAME")]
        public string LastName { get; set; }
        [DataMember(Name = "ORGANIS")]
        public string Organisation { get; set; }
    }
