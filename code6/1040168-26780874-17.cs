    static uint max_factor32 (double n)
    {
       double r = System.Math.Sqrt(n);
    
       if (r < uint.MaxValue)
       {
          uint r32 = (uint)r;
    
          return r32 - ((ulong)r32 * r32 > n ? 1u : 0u);
       }
    
       return uint.MaxValue;
    }
    
    static void sieve32 (System.Collections.BitArray odd_composites)
    {
       uint max_bit = (uint)odd_composites.Length - 1;
       uint max_factor_bit = max_factor32((max_bit << 1) + 1) >> 1;
    
       for (uint i = 3 >> 1; i <= max_factor_bit; ++i) 
       {
          if (odd_composites[(int)i])  continue;
    
          uint p = (i << 1) + 1;  // the prime represented by bit i
          uint k = (p * p) >> 1;  // starting point for striding through the array
    
          for ( ; k <= max_bit; k += p)
          {
             odd_composites[(int)k] = true;
          }
       }
    }
    
    static int Main (string[] args)
    {
       int n = 100000000;
    
       System.Console.WriteLine("Hello, Eratosthenes! Sieving up to {0}...", n);
    
       System.Collections.BitArray odd_composites = new System.Collections.BitArray(n >> 1);
    
       sieve32(odd_composites);
    
       uint cnt = 1;
       ulong sum = 2;
    
       for (int i = 1; i < odd_composites.Length; ++i)
       {
          if (odd_composites[i])  continue;
    
          uint prime = ((uint)i << 1) + 1;
    
          cnt += 1;
          sum += prime;
       }
    
       System.Console.WriteLine("\n{0} primes, sum {1}", cnt, sum);
    
       return 0;
    }
