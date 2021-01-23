    using System;
    using System.Linq.Expressions;
    namespace TestApplication
    {
      internal class CompilerTest
      {
        public void Test()
        {
          Func<bool> func = (Func<bool>) (() => true);
          (Expression<Func<bool>>) (() => true || CompilerTest.Foo());
        }
    
        public static bool Foo()
        {
          return new Random().Next() % 2 == 0;
        }
      }
    }
