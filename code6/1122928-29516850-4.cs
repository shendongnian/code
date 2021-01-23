        public class BucketGroup
        {
          public int Id {get;set;} 
          public string Name {get;set;}
         
          [ForeignKey("ParentBucketGroup")]
          public int? ParentBucketGroupId {get;set;}
        
          public virtual BucketGroup ParentBucketGroup {get;set;}
          public virtual ICollection<BucketGroup> Children { get; set; }
        }
