    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myClass1 = new MyClass();
                var myClass2 = new global::MyClass();
            }
    
            public class MyClass { }
        }
    }
    
    public class MyClass { }
