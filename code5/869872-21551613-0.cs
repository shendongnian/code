    public class ContactModel
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
    public class PersonModel
    {
        public ContactModel Contact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
    }
