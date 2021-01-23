    [DataContract]
    public class Person
    {
        [DataMember(Name="firstname")]
        public string FirstName { get; set; }
        [DataMember(Name="lastname")]
        public string LastName { get; set; }
    }
