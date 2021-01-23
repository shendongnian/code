    public abstract class BasePlugin
    {
      public void SomeMethod(){
          // default code before/after one or many variations 
          // to be provided by derived classes
          ...
          Variation(....);
          ...
       }
       public virtual Variation(....) {} // nothing by default
    } 
