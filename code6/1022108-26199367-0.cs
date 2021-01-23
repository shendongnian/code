    namespace context1
    {
        public class A
        {
            internal String s = "context1";
        }
    }
    
    namespace context2
    {
        public class A
        {
            internal String s = "context2";
        }
    }
    
    namespace common
    {
        public static class ExtensionsForA
        {
            public static void f(this context1.A a) { common_f(a.s); }
            public static void f(this context2.A a) { common_f(a.s); }
    
            private static void common_f(string s) { Console.WriteLine(s); }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                context1.A a1 = new context1.A();
                context2.A a2 = new context2.A();
                a1.f();
                a2.f();
                Console.ReadKey();
            }
        }
    }
