        public class BucketGroup
        {
          public int Id {get;set;} 
          public string Name {get;set;}
         
          public int? ParentBucketGroupId {get;set;}
        
          public virtual BucketGroup ParentBucketGroup {get;set;}
          public virtual ICollection<BucketGroup> Children { get; set; }
        }
    And, to configure the relationship, you could override the `OnModelCreating` method on your context:
        modelbuilder.Entity<BucketGroup>().HasOptional(b=>b.ParentBucketGroup )
                                        .WithMany(b=>b.Children )
                                        .HasForeignKey(b=>b.ParentBucketGroupId);
