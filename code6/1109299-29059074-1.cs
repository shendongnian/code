    public class Category
    {
        [Key]
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        //Navigation property to reference the RegistrationForms
        public virtual ICollection<RegistrationForm> RegistrationForms { get; set; }
    }
