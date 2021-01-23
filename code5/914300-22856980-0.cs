    public class Employee : IdentityUser
    { 
       public String Name { get; set; }
       public string ManagerID { get; set; }
       [Required]
       public virtual Employee Manager { get; set; }
       public virtual Employee TeamLead { get; set; }
    } 
