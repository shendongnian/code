    using System;
    
    static class Program
    {
        static void Main()
        {
            A();
        }
    
        static void A()
        {
            Console.WriteLine("A before");
            B();
            Console.WriteLine("A after");
        }
    
        static void B()
        {
            Console.WriteLine("B before");
            C();
            Console.WriteLine("B after");
        }
    
        static unsafe void C()
        {
            int local;
    
            int* localPointer = &local;
    
            localPointer[2] = localPointer[4];
        }
    }
