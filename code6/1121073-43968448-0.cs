    using System;
    namespace ConsoleApplication3
    {
        public class Program
        {
            static void Main(string[] args)
            {
                Class1 cl = new Class1();
                cl.TestMethod();
            }
        }
        public class Class1
        {
            public string TestMethod()
            {
                return "test";
            }
        }
        public class Class2
        {
            Class1 cl = new Class1();
            
            public Class2()
            {
                cl.TestMethod();
            }
        }
    }
