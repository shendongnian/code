    using System;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    
    namespace TestApplication
    {
      internal class CompilerTest
      {
        [CompilerGenerated]
        private static Func<bool> CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1;
    
        public CompilerTest()
        {
          base.\u002Ector();
        }
    
        public void Test()
        {
          if (CompilerTest.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1 == null)
          {
            // ISSUE: method pointer
            CompilerTest.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1 = new Func<bool>((object) null, __methodptr(\u003CTest\u003Eb__0));
          }
          Func<bool> func = CompilerTest.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1;
          (Expression<Func<bool>>) (() => true || CompilerTest.Foo());
        }
    
        public static bool Foo()
        {
          return new Random().Next() % 2 == 0;
        }
    
        [CompilerGenerated]
        private static bool \u003CTest\u003Eb__0()
        {
          return true;
        }
      }
    }
