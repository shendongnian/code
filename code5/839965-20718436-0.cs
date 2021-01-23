    public class EventReg
    {
       public EventReg()
       {
           HashTags = new HashSet<HashTag>();
       }
       //...your other fields
       public virtual ICollection<HashTag> HashTags { get; set; }
    }
    public class HashTag
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int HashTagID {get;set;}
        
        public string HashTagName {get;set;}
        public virtual EventReg EventReg { get; set; }
    }
