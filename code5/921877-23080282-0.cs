    public class User
        {
            public User() 
            { 
            }
    
            public int idUser; { get; set; }
            [Required]
            public string UserName { get; set; }
    
            
            public virtual Computer Computer{ get; set; }
    
        }
    
    
    public class Computer
        {
            public Computer() 
            {
            }
            [Key, ForeignKey("User")]
            public int idUser{ get; set; }
            
            public string ComputerName {get;set;}
    
            public virtual User User { get; set; }
        }
