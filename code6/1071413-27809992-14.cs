    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [InverseProperty("Contacts")]
        public virtual Person Person { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
