    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                foo(bar);
    
                Console.ReadKey();
            }
    
            public static bool bar(string pVal)
            {
                throw new Exception("hello there");
            }
    
            public static void foo(Func<string, bool> pFunc)
            {
                try
                {
                    pFunc("test");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: "+ ex.Message);
                }
            }
        }
    }
