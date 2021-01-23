    public class A
    {
      private static object lockObj = new object();
    
      public MyCustomClass sharedObject;
      public void Foo()
      {
        lock(lockObj)
        {
           
          //codes here are safe 
          //shareObject.....
        }
      }
    
    }
