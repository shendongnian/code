        public class Type1 {
            public int ID { get; set; }
            public virtual ContainerClass {get; set;}
        }
        
        public class Type2 {
        
            public int ID { get; set; }
            public virtual ContainerClass {get; set;}
        }
    
        public class ContainerClass {
             public int ID {get;set;}
             public virtual Type1 @Type1 {get;set;}
             public virtual Type2 @Type2 {get;set;}
    }
