    public class Venue : BaseObject, IBaseObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}
       
        public int OwnerId{get;set;}
    
        [Required]
        public virtual User Owner { get; set; }
    
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
    public class User : BaseObject, IBaseObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
    
        [Required]
        public string Name { get; set; }
    
        [Required]
        [DisplayName("Email")]
        public string EmailAddress { get; set; }
    
        [Required]
        public string Password { get; set; }
    
        public bool Active { get; set; }
    
    
        public virtual ICollection<Venue> Venues { get; set; } 
    }
