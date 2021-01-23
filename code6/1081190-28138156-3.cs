    public class User
    {
       [Key]
       public int  Id  { get; set; }
       public virtual Customer Customer { get; set; }
    }
    public class Customer
    {
       [Key, ForeignKey("User")]
       public int  UserId { get; set; }
       public virtual User User{ get; set; } 
    }
