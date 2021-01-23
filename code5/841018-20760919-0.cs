    public class EntityA : EntityABase {
        
    }
    public abstract class EntityABase {
        
        [Key]
        public int id { get; set; } 
        public int prop1 { get; set; }
        public virtual AnotherEntity { get; set; }
    }
    public class EntityB : EntityABase {
        
        [Key]  
        public virtual EntityC { get; set; }
    }
