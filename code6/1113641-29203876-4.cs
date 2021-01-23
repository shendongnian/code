    [DataContract]
    public class Person : PropertyChangedBase
    {
        [DataMember]
        public int Id { get; set; }
        private string _firstName;
        [DataMember]
        public string FirstName { get; set; }
    }
