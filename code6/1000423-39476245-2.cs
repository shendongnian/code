    public class ContactSummary
    {
        public string Name { get; set;}
        public string Phone { get; set; }
    }
    public class Contact
    {
        public ContactSummary Summary { get; set; }
        // ... other properties here
    }
            
