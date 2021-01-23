    public abstract class PriceMethod
    {
      // Prevent inheritance from outside.
      private PriceMethod() {}
    
      public abstract decimal Invoke(List<decimal> list);
      
      public static PriceMethod Max = new MaxMethod();
    
      private sealed class MaxMethod : PriceMethod
      {
        public override decimal Invoke(List<decimal> list)
        {
          return list.Max();
        }
      }
    
      // etc, 
    }
