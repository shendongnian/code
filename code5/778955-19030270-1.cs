    public abstract class BaseEngine
    {
      public void DoStuff()
      {
        // Do some things here
        DoDerivedStuff();
        // Do some other things here
      }
      protected abstract void DoDerivedStuff();
      public virtual void DoOverridableStuff()
      {
        // Do stuff in here.
      }
    }
    public class Engine : BaseEngine
    {
       protected override void DoDerivedStuff()
       {
         // Do stuff here that is particular to this derived type.
       }
       public override void DoOverridableStuff()
       {
          // Do additional stuff for the Engine class if necessary
          base.DoOverridableStuff(); // You can omit this if you don't 
                                     // want to do what the base is doing.
          // Do more stuff for the engine class if necessary
       }
    }
