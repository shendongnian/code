     {
      // map for Dependant
      // Relationship
            this.HasKey(t => t.Id);
            // Properties
            //Id is an int allocated by DB but controller via Primary here
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // from parent
            entity.HasRequired(t => t.NAV_PROP_TO_PRIMARY)
                  .WithOptional(t => t.NAV_PROP_DEPENDANT) // if it is declared. NOT required.
                  .WillCascadeOnDelete(true);   // as appropriate
     }   
 
     {
         //map for Primary
         // Primary Key
         this.HasKey(t => t.Id);
         // Properties
         //Id is an int allocated by DB
        this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // default to db generated
     }
    public class Dependant{ 
       public  virtual int Id { set; get; }
       //... other props
       public virtual Primary Primary {get; set;}   // nav to primary
    } 
    public class Primary{ 
       public  virtual int Id { set; get; }
       
    } 
    
