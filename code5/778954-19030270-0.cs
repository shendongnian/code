    public abstract class BaseEngine
    {
      public void DoStuff()
      {
        // Do some things here
        DoDerivedStuff();
        // Do some other things here
      }
      protected abstract void DoDerivedStuff();
    }
    public class Engine : BaseEngine
    {
       protected override void DoDerivedStuff()
       {
         // Do stuff here that is particular to this derived type.
       }
    }
