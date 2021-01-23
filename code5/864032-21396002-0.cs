    interface IHasTheStuff
    {
      bool HaveStuff();
    }
    public abstract class BaseController<TElement> : IHasTheStuff, Controller ...
    {
       ...
       public bool HaveStuff() { return Stuff != null;}
    }
