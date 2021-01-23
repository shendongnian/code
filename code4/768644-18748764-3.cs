    public class RuleNumberOne : IRules
    {
       public decimal Execute(object date)
       {
          if(object.Time > 0 && object.Something <= 499)
             return .75m;
          return 0;
       } 
    } 
 
    public class RuleNumberTwo : IRules
        {
           public decimal Execute(object date)
           {
             if(object.Time >= 500 && object.Something <= 999)
                 return .85m;
              return 0;
           } 
    } 
    public interface IRules
    { 
      decimal Execute(object something);
    }
