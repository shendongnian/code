    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            int[] values = new int[10];
            Foo(ref values[0]);
            Console.WriteLine(values[0]); // 10
        }
        
        static void Foo(ref int x)
        {
            x = 10;
        }
    }
