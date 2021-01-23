    public class MyModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        [Sortable]
        public int Name { get; set; }
    }
