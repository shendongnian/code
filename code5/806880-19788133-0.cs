    using System;
    
    struct Foo : IDisposable
    {
        public Foo(string msg)
        {
            Console.WriteLine("Init: " + msg);
        }
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    
    }
    
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Before");
            using (new Foo("Hi"))
            {
                Console.WriteLine("Do stuff");
            }
            Console.WriteLine("After");
        }
    }
