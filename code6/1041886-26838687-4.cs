    public class Person
    {
        public Person()
        {
        }
        public Person(string fName, string lName, ContactInfo contactInfo)
        {
            FirstName = fName;
            LastName = lName;
            ContactInfo = contactInfo;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
