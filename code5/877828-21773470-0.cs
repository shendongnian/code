    using System;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static smallclass objA = new smallclass();
            private static smallclass objB = new smallclass();
    
            private static void Main(string[] args)
            {
                showValues();
    
                objA.value = 1000;
    
                showValues();
    
                objB = objA;
    
                showValues();
    
                objA.value = 1055;
    
                showValues();
            }
    
            private static void showValues()
            {
                Console.WriteLine("objA.value: " + objA.value);
                Console.WriteLine("objB.value: " + objB.value);
    
                Console.ReadLine();
            }
        }
    
        internal class smallclass : IDisposable
        {
            public int value = 0;
    
            public void Dispose()
            {
                //Here you can remove eventHandlers
                //or do some other stuff before the GC will play with it
            }
        }
    }
