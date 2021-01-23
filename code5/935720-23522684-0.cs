    using System.IO;
    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            bool   flip, strike;
            int    eps, lo, hi;
            Random rnd;
            
            eps = Int32.Parse(args[0]); // whatever is appropriate
            
            rnd = new Random();
            lo = rnd.Next(Int32.MaxValue);
            hi = rnd.Next(Int32.MaxValue);
            flip = (rnd.Next() > 0.5); 
            if (flip) { int swap; swap = lo; lo = hi; hi = swap; }
            
            strike = (hi == 0) && (lo < eps);
            
            Console.Write("[hi lo] = ");
            Console.Write(hi);
            Console.WriteLine(lo);
            if (strike) {
                Console.WriteLine("strike");
            }
        }
    }
