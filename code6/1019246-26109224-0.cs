    public class MyLazyWidget
    {
      . . .
      public BigExpensiveObject MyLazyProperty
      {
        get
        {
          if ( BigExpensiveObjectBackingStore == null )
          {
            BigExpensiveObjectBackingStore = ExpensiveOperation() ;
          }
            return BigExpensiveObjectBackingStore ;
        }
      }
      private static BigExpensiveObjectBackingStore = null ;
      . . .
    }
