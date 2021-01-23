    public class UserRole
    {
      [Key]
      [Required]
      [StringLength(45)]
      public string Id { get; set; }
    
      [Required]
      [StringLength(45)]
      public string Name { get; set; }
    
      public string Description { get; set; }
    }
    
    public class User
    {
      [Key]
      [Required]
      [StringLength(45)]
      public string Id { get; set; }
    
      [Required]
      [StringLength(45)]
      public string Name { get; set; }
    
      [Required]
      [StringLength(45)]
      public string pwd { get; set; }
    
      [Required]
      [StringLength(45)]
      public virtual string UserRole { get; set; }
    
      [Required]
      [ForeignKey("UserRole")]
      public virtual UserRole Role { get; set; }
    }
