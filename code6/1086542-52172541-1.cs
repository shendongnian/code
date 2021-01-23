    using System;
    using System.Collections.Generic;
     
    public class Test
    {
        static void Main()
        {
            int[] ints = { 10001, 10002, 10003, 10004, 10005 };
            int hash = GetHashCode(ints);
            int[] reorderedInts = { 10004, 10002, 10005, 10001, 10003 };
            int reorderedHash = GetHashCode(reorderedInts);
     
            Console.WriteLine("hash          == {0}", hash);
            Console.WriteLine("hashReordered == {0}", reorderedHash);
        }
     
        static int GetHashCode(IEnumerable<int> integers)
        {
            int hash = 0;
     
            foreach(int integer in integers)
            {
                int x = integer;
     
                x ^= x >> 17;
                x *= 830770091;   // 0xed5ad4bb
                x ^= x >> 11;
                x *= -1404298415; // 0xac4c1b51
                x ^= x >> 15;
                x *= 830770091;   // 0x31848bab
                x ^= x >> 14;
     
                hash ^= x;
            }
     
            return hash;
        }
    }
