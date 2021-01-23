    using System;
    
    class Test
    {
        delegate void Foo(int x, int y);
        
        static void Main()
        {
            Foo foo = (x, y) => Console.WriteLine("x={0}, y={1}", x, y);
            foo(x: 5, y: 10);
            foo(y: 10, x: 5);
        }
    }
