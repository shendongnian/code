    public class X
    {
         private readonly static _syncLock = new object();
    
         public void DoStuff()
         {
              lock(_syncLock) 
              {
                 // Critical section
              }
         }
    }
