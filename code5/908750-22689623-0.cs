    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<Contact> Contacts { get; set; }
    }
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? LanguageTypeID { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("LanguageTypeID")]
        public LanguageType Language { get; set; }
    }
    public class LanguageType : Lookup
    {
        public string CultureName { get; set; }
    }
    public class Lookup : BaseEntity
    {
        public string DisplayName { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public ApplicationUser CreatedByUser { get; set; }
        public ApplicationUser UpdatedByUser { get; set; }
    }
    public class ApplicationUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
