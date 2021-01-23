     public class BaseItem
     {
       [Key]
       public int Id { get; set; }
       public List<BaseRevision> Revisions { get; set; }
      }
     public class BaseRevision
     {
        [Key]
        public int Id { get; set; }
        public Int BaseItemID{get;set;}
        [ForeignKey("BaseItemID")]
         public BaseItem Item { get; set; }
      }
