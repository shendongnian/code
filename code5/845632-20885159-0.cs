    public class CustomerLocations: BaseEntity
        {
           [Key]
           public int ID { get; set; }
    
          public Customer Customer {get;set;}
           public virtual LocationType LocationType { get; set; }
           public virtual Location Location { get; set; }
        }
    public enum LocationType{
    
    Billing=1,
    Shipping=2
    }
