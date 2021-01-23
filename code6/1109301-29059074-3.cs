    public class RegistrationForm
    {
        [Key]
        public int RegistrationID { get; set; }
        ...
        // add a navigation property ICollection<Category> to reference the categories
        public virtual ICollection<Category> Categories { get; set; }
    }  
