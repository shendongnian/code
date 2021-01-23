        using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Example NewExample = new Example();
                //NewExample.DoSomething(); //Ambiguous error
                ExtensionClass1.DoSomething(NewExample); //OK
            }
        }
        public class Example
        {
        }
        public static class ExtensionClass1
        {
            public static void DoSomething(this Example A)
            {
            }
        }
        public static class ExtensionClass2
        {
            public static void DoSomething(this Example A)
            {
            }
        }
    }
