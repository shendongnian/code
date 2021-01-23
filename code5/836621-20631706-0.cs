    public class BaseClass
    {
      public abstract void DoStuff();
    
      protected void DoStuffInternal()
      {
        // do something
      }
    }
    
    public class DerivedClass : BaseClass
    {
      public override void DoStuff()
      {
         // do derived work
         DoStuffInternal();
      }
    }
