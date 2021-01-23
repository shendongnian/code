    public class Stuff
    {
        public int Id { get; set; }
        
        public int? NextVersionId { get; set; }
    
        public int? PrevVersionId { get; set; }
        
        [ForeignKey("NextVersionId")]
        public virtual Stuff NextVersion { get; set; }
    
        [ForeignKey("PrevVersionId")]
        public virtual Stuff PrevVersion { get; set; }
    
    }
