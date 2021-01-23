        public class BucketGroup
        {
          public int Id {get;set;} 
          public string Name {get;set;}
         
          public int? ParentBucketGroupId {get;set;}
        
          public virtual BucketGroup ParentBucketGroup {get;set;}
          public virtual ICollection<BucketGroup> Children { get; set; }
        }
    And, to configure the relationship, you could override the `OnModelCreating` method on your context:
        modelbuilder.Entity<Appoiment>().HasOptional(a=>a.ParentBucketGroup )
                                        .WithMany(au=>au.Children )
                                        .HasForeignKey(a=>ParentBucketGroupId);
