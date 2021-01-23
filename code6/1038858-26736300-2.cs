    public class MyObject 
    {
      private SynchronizationContext CurrentSynchronizationContext;
      public MyObject()
      { 
        CurrentSynchronizationContext = System.Threading.SynchronizationContext.Current;
      }
    }
