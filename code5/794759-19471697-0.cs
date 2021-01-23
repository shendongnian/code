    using System;
    using MyFamiliarNamespace = MyScaryNamespace;
    using MyFamiliarClass = MyScaryNamespace.MyScaryClass;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var @class = new MyFamiliarClass();
                @class.HelloWorld();
            }
        }
    
        public static class MyScaryClassExtensions
        {
            public static void HelloWorld(this MyFamiliarClass myScaryClass)
            {
                Console.WriteLine("Hello world !");
            }
        }
    }
    // Consider this part being in another assembly
    namespace MyScaryNamespace
    {
        public class MyScaryClass
        {
        }
    }
