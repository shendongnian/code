    public class InteractiveObject
    {
         public int Id{ get; set; } // own InteractiveObject's Id
         public string Name{ get; set; }
    
         public int? IndicatorId { get; set; }
         public virtual Indicator Indicator { get; set; }
    }
    
    public class Indicator
    {
         public int Id{ get; set; } // own Indicator's Id
         public string Name{ get; set; }
    
         public int InteractiveObjectId { get; set; }
         public virtual InteractiveObject InteractiveObject { get; set; }
    }
