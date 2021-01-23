    public class Contact
    {
        public int Id { get; set; }
 
        public virtual Person Person { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
