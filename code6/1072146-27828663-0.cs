    public abstract class Stampable 
    {
      [Key]
      public int ID { get; set; } 
    
      [Required]
      public string ModStamp { get; set; }
    }
