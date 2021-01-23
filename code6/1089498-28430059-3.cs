    public class Person
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public virtual ICollection<CLanguage> Languages { get; set; }
        public Person()
        {
            Languages = new List<CLanguage>();
        }
    }
