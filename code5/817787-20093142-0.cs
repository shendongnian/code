    namespace MyNamespace
    {
        interface ITest
        {
    
        }
    
        class Timpl : ITest
        {
    
        }
    
        class Test<T> where T : ITest
        {
            public T get()
            {
                return default(T);
            }
        }
    
        public class mycls : ITest
        {
    
    
        }
    
        class MyClass
        {
            public MyClass()
            {
                Test<mycls> s = new Test<mycls>(); //will compile
            }
        }
    }
