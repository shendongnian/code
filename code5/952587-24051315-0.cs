    public interface IExample{
          int Test{get;}
    }
    
    public class Example : IExample{
          private int _test;
          public int Test{
                private set{
                   _test=value;
                }
                get{
                   return _test;
                }
          }
    }
