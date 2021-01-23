    using System;
    using System.Diagnostics;
    
    class Program
    {
        static void Main()
        {
            int a = 5, b = 10;
            Console.WriteLine("hello");
            Debug.Assert(a != b); // should get past this
            Console.WriteLine("world");
            b = 5;
            Debug.Assert(a != b); // should fail in debug mode
        }
    }
