    public class Member
    {
    [Key]
    public int Id {get;set;}
    
    ...
    
    public virtual Address Address {get;set;}
    }
    
    public class Address
    {
    [ForeignKey("Member")]
    public int Id {get;set;}
    
    ...
    
    public virtual Member Member {get;set;}
    }
