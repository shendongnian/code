    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
        
        [ForeignKey("PrincipalContact")]
        public int? PrincipalContactId { get; set; }
        public virtual Contact PrincipalContact { get; set; }
    }
    public class Contact
    {
        [Key]
        [ForeignKey("AccountOf")]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Account AccountOf { get; set; }
    }
