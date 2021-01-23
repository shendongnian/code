    public abstract class HasKeyValuePairs
    {
       [Key]
       public virtual string Id { get; set; }
    
       [NotMapped]
       public ICollection<KeyValuePair> Properties
       {
          get
          {
              using(var db = new DbContext())
              {
                 return db.KeyValuePairs.Where(kvp => kvp.OwnerID == this.ID);
              }
          }
       }
    }
