    using System;
        
    namespace BitSwap
    {
      class Program    
      {
        static void Main()        
        {
            //swaps bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of n.
            Console.WriteLine("n=");
            uint n = uint.Parse(Console.ReadLine());
            Console.WriteLine("p=");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("q=");
            int q = int.Parse(Console.ReadLine());
            Console.WriteLine("k=");
            int k = int.Parse(Console.ReadLine());
            int i;
            int s;
            if ((p + k - 1) < 32 && (q + k - 1) < 32 && p > 0 && q > 0)
            // for integer
            {
                for (i = p, s = q; i <= p + k - 1 && s <= q + k - 1; i++, s++)
                {
                    uint firstBits = (n >> i) & 1;
                    uint secondBits = (n >> s) & 1;
                    uint maskFirstBits = (uint)1 << i;
                    uint maskSecondBits = (uint)1 << s;
                    n = (n & ~maskFirstBits) | (secondBits << i);
                    n = (n & ~maskSecondBits) | (firstBits << s);
                }
                Console.WriteLine("Result: {0}", n);
            }
            else
            {
                Console.WriteLine("Invalid entry.");
            }
         }
       }
     }
