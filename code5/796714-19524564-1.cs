    public abstract class PriceMethod
    {
      // Prevent inheritance from outside.
      private PriceMethod() {}
    
      public abstract decimal Invoke(IEnumerable<decimal> sequence);
      
      public static PriceMethod Max = new MaxMethod();
    
      private sealed class MaxMethod : PriceMethod
      {
        public override decimal Invoke(IEnumerable<decimal> sequence)
        {
          return sequence.Max();
        }
      }
    
      // etc, 
    }
