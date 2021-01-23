    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
        public Contact PrincipalContact { get; set; }
    }
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Account Account { get; set; }
        public int? AccountId { get; set; }
    }
