    namespace Namespace1
    {
        public class Class1
        {
          string test = global::Const.EXAMPLE;
          string test2 = Namespace1.Class1.Const.EXAMPLE;
        
          public static class Const
          {
            ......
            ......
          }
        }
    }
