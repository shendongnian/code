    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public int? Person_Id { get; set; }
        [ForeignKey("Person_Id"), InverseProperty("Contacts")]
        public virtual Person Person { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
