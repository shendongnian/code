    public class RuleNumberOne : IRules
    {
       public decimal Execute(Oobject date)
       {
          if(date.Time > 0 && date.Something <= 499)
             return .75m;
          return 0;
       } 
    } 
    public class RuleNumberTwo : IRules
    {
        public decimal Execute(Oobject date)
        {
            if(date.Time >= 500 && date.Something <= 999)
                return .85m;
            return 0;
        } 
    } 
    public interface IRules
    { 
      decimal Execute(Oobject date);
    }
