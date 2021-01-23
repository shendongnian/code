    using System;
    using System.Linq;
    
    enum Foo { }
    
    class Test
    {
        static void Main()
        {
            Foo[] x = new Foo[10];
            // False because the C# compiler is cocky, and "optimizes" it out
            Console.WriteLine(x is int[]);
            
            // True because when we put a blindfold in front of the compiler,
            // the evaluation is left to the CLR
            Console.WriteLine(((object) x) is int[]);
            
            // Foo[] and True because Cast returns the same reference back
            Console.WriteLine(x.Cast<int>().GetType());
            Console.WriteLine(ReferenceEquals(x, x.Cast<int>()));
        }
    }
