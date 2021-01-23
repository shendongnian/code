    using System;
    
    namespace Test81
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                bool b;
                unsafe
                {    
                    bool* p1 = &b; 
                    Console.WriteLine("p1: 0x{0:X}", new IntPtr(p1).ToInt64());
                }
            }
        }
    }
