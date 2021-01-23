    public class PrimaryEntity
    {
        // primary key
        public Guid Id { get; set; }
        // some other properties...
        public RelatedEntity Related { get; set; }
    }
    public class RelatedEntity
    {
        // both the primary and foreign key
        public Guid PrimaryEntityId { get; set; }
        
        // some other properties
     }
     //mapping
     //configure the primary key as mentioned above
     modelBuilder.Entity<RelatedEntity>() 
          .HasKey(t => t.PrimaryEntityId );
     modelBuilder.Entity<PrimaryEntity>()
          .HasRequired(p => p.Related )
          .WithRequiredPrincipal(); //empty parenthesis for one sided navigation.
