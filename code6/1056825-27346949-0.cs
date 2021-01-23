    public class C
    {
        [ForeignKey("A")]
        public int AId {get; set;}
        [ForeignKey("B")]
        public int BId {get; set;}
    
        public virtual A a {get; set;}
        public virtual B b {get; set;}
    }
