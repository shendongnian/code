    public class Type1 {
        public int ID { get; set; }
    }
    
    public class Type2 {
    
        public int ID { get; set; }
        public virtual Type1 @Type1 { get; set; }
    }
