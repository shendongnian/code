    public class Stuff
    {
        public int Id { get; set; }
        
        public int? NextVersionId { get; set; }
    
        public int? PrevVersionId { get; set; }
        
        public virtual Stuff NextVersion { get; set; }
        public virtual Stuff PrevVersion { get; set; }
    
    }
