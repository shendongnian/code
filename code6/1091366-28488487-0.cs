    using System;
    using System.Reflection;
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fields = typeof(Foo).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine(fields[0].Name);
            }
        }
        class Foo
        {
            public int Bar { get; set; }
        }
    }
