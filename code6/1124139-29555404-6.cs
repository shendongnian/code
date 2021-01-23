     public class Indicator
        {
            [ForeignKey("InteractiveObject")]
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            public virtual InteractiveObject InteractiveObject { get; set; }
        }
    
        public class InteractiveObject
        {
           
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            public virtual Indicator Indicator { get; set; }
        }
