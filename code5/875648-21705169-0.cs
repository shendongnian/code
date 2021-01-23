    using System;
    
    class Test
    {
        static void MyMethod(params object[] args)
        {
            Console.WriteLine(args.Length);
        }
     
        static void Main()
        {
            object[] args = { "foo", "bar", "baz" };
            MyMethod(args);
        }
    }
