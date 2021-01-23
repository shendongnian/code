    using System;
    class Program 
    { 
        static void Main(string[] args) 
        { 
            int size = 10000000;
            object array = null;
            long before = GC.GetTotalMemory(true); 
            array = new bool[size];
            long after = GC.GetTotalMemory(true); 
             
            double diff = after - before; 
             
            Console.WriteLine("Per value: " + diff / size);
    
            // Stop the GC from messing up our measurements 
            GC.KeepAlive(array); 
        } 
    }
