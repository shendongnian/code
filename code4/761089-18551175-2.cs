    using System;
    
    class Test
    {
        const int Size = 100000;
    
        static void Main()
        {
            Console.WriteLine("Running at {0} bits", IntPtr.Size * 8);
    
            Tester<string>();
            Tester<double>();
    
            Console.ReadKey();
        }
    
        static void Tester<T>()
        {
            var array = new object[Size];
            long initialMemory = GC.GetTotalMemory(true);
    
            for (int i = 0; i < Size; i++)
            {
                array[i] = new T[0];
            }
    
            long finalMemory = GC.GetTotalMemory(true);
            
            GC.KeepAlive(array);
    
            long total = finalMemory - initialMemory;
    
            Console.WriteLine("Size of each {0}[]: {1:0.000} bytes", typeof(T).Name,
                              ((double)total) / Size);
        }
    }
