     public class Indicator
        {
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            public virtual InteractiveObject InteractiveObject { get; set; }
        }
    
        public class InteractiveObject
        {
            [ForeignKey("Indicator")]
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            public virtual Indicator Indicator { get; set; }
        }
