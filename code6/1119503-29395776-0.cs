    using System;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class SomeClass
        {
            public void A() { }
            public void B() { }
            public void C() { }
            public void D() { }
            public void E() { }
            public void F() { }
        }
        class Program
        {
            static void Main()
            {
                var methods = GetMethods(typeof (SomeClass));
                foreach (var methodName in methods)
                {
                    Console.WriteLine(methodName);
                }
            }
            private static string[] GetMethods(Type type)
            {
                var methods = type.GetMethods();
                return methods.Select(m => m.Name).ToArray();
            }
        }
    }
