    public class Base<T> where T : Base<T>
    {
          public T Common()
          {
              return (T)this;
          }
    }
    
    public class XBase : Base<XBase>
    {
         public XBase XMethod()
         {
              return this;
         }
    }
