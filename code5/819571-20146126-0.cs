    public class Profile {
    [Key]
    public int ProfileId {get;set;}
    Public int UserId {get;set} 
    [Required]
    [ForeignKey("UserId")] // check syntax  
    public virtual User User {get;set;}
    }
 
