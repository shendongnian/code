    public class RelatedEntity
    {
       // both the primary and foreign key
       public Guid PrimaryEntityId { get; set; }
    
       public PrimaryEntity Primary { get; set; }
       // some other properties
    }
