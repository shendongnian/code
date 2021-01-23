    static class Program
    {
        public static bool IsFound(this System.Collections.BitArray text, System.Collections.BitArray pattern)
        {
            uint B = 0;
            for (ushort i = 0; i < pattern.Length; i++)
            {
                if (pattern[i])
                {
                    uint num = 1;
                    B |= num << i;
                }
            }
            return IsFound(text, B);
        }
        public static bool IsFound(this System.Collections.BitArray text, uint B)
        {
            uint nB = ~B;
            uint D = 0;
            const uint end = ((uint)1) << 31;
            for (int i = 0; i < text.Length; i++ )
            {
                uint uD = (D << 1) + 1;
                D = uD & (text[i] ? B : nB);
                if ((D & end) > 0)
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            System.Collections.BitArray bitsarr = new System.Collections.BitArray(150);
            
            //Tests:
            bitsarr[0] = true;
            bitsarr[1] = true;
            bitsarr[2] = false;
            bitsarr[3] = true;
            
            bitsarr[50] = true;
            bitsarr[51] = true;
            bitsarr[52] = true;
            bitsarr[53] = false;
            bitsarr[54] = false;
            bool result = bitsarr.IsFound(new System.Collections.BitArray(new bool[]{true, true, false, true}));
            Console.WriteLine("Result: {0}, expected True", result);
            result = bitsarr.IsFound(new System.Collections.BitArray(new bool[] { true, true, true, true }));
            Console.WriteLine("Result: {0}, expected False", result);
            result = bitsarr.IsFound(new System.Collections.BitArray(new bool[] { true, true, true, false }));
            Console.WriteLine("Result: {0}, expected True", result);
            result = bitsarr.IsFound(new System.Collections.BitArray(new bool[] { false, true, true, true }));
            Console.WriteLine("Result: {0}, expected True", result);
            result = bitsarr.IsFound(new System.Collections.BitArray(new bool[] { false, true, true, true }));
            Console.WriteLine("Result: {0}, expected True", result);
            Console.ReadKey();
        }
        
    }
