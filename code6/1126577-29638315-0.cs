    public class Company {
       public int Id { get; set; }        
       
       [Required]
       [Key, ForeignKey("User")]
       public string UserId { get; set; }       
           
       public User User { get; set; }
   }
