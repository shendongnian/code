    public class Stuff
    {
        public int Id { get; set; }
        
        public int? NextVersionId { get; set; }
    
        [ForeignKey("NextVersionId ")]
        public virtual Stuff NextVersion { get; set; }
    
    }
