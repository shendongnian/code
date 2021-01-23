    [Serializable]
    public class Personal
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Occupation { get; set; }
        public string Website { get; set; }
    }
    [Serializable]
    public class Address
    {
        public string Country { get; set; }
        public string Address { get; set; }
        public string AptNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
    [Serializable]
    public class ProfileInfo
    {
        public Personal Personal { get; set; }
        public Address Address { get; set; }
    }
