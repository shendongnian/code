    using System;
    
    namespace Foo.iOS
    {
        public class Foo
        {
            public static void doThis() { Console.Write("Inside doThis");}
        }
    }
    
    namespace Sample.iOS
    {
        using Foo.iOS;
    
        class Program
        {
            static void Main(string[] args)
            {
                method();
                Console.ReadKey();
            }
    
            public static void method () 
            {
                // works fine
                Foo.doThis();
            }
        } 
    }
