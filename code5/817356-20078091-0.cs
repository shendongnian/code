    public abstract class Base<T>
    {
          public Base Common()
          {
              return this;
          }
          
         public abstract T XMethod();
    }
    
    public class XBase : Base<XBase>
    {
    
         public override XBase XMethod()
         {
              return this;
         }
    }
