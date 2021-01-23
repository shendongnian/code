    using System;
    namespace Demo
    {
        public static class Console
        {
            public static void WriteLine(string unused)
            {
                System.Console.WriteLine("False");
            }
        }
        public static class Program
        {
            private static void Main(string[] args)
            {
                if(true)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }        
            }
        }
    }
