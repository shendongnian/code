    public class Profile {
    [Key]
    public int ProfileId {get;set;}
    [Required]
    [ForeignKey("User")] 
    Public int UserId {get;set} 
   
    public virtual User User {get;set;}
    }
 
