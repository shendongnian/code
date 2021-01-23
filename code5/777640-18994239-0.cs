    public class MyGadget<T>
    {
      static readonly SyncRoot = new object() ;
      
      public T SynchronizedMethod()
      {
         lock ( SyncRoot )
         {
            SynchronizedMethodGuts() ;
         }
      }
      
    }
