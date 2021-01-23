    public class MyLazyWidget
    {
      . . .
      public BigExpensiveObject MyLazyProperty
      {
        get
        {
          lock( MyLazyPropertyLatch )
          {
            if ( BigExpensiveObjectBackingStore == null )
            {
              BigExpensiveObjectBackingStore = ExpensiveOperation() ;
            }
          }
          return BigExpensiveObjectBackingStore ;
        }
      }
      private static readonly object MyLazyPropertyLatch = new object() ;
      private static BigExpensiveObjectBackingStore = null ;
      . . .
    }
