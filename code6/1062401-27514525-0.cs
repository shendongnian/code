    using System;
    using System.Linq.Expressions;
    
    namespace TestApplication
    {
        class CompilerTest
        {
            public void Test()
            {
                Func<bool> func = () => true || Foo();
                Expression<Func<bool>> expr = () => true || Foo();
            }
    
            public static bool Foo()
            {
                return new Random().Next() % 2 == 0;
            }
        }
    }
