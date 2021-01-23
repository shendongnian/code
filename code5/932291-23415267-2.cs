    using System;
    
    internal class Program
    {
        private static unsafe void Main(string[] args)
        {
            Point point = new Point { X = 10, Y = 20};
            long a = 1;
            long* pA = &a;
            
            Console.WriteLine("'a' pointer value: \t{0}", *pA);
            Console.WriteLine("'a' pointer address: \t{0:x16}", (long)pA);
            Console.WriteLine("'point' value: \t\t{0:x16}", *(pA - 1));
    
            // the location of 'point' on the stack
            long prP = (long)(pA - 1); 
            long* pP = *(long**)prP;
            Console.WriteLine("'point' address: \t{0:x16}", *pP);
            Console.WriteLine("'point.Y' value: \t{0}", *(pP + 1));
            Console.WriteLine("'point.X' value: \t{0}", *(pP + 2));
    
            Console.ReadLine();
        }
    }
    
    internal class Point
    {
        public int X;
        public long Y;
    }
