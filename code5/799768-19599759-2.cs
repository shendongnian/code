    namespace StackOverFlow
    {
        static class Program
        {
            public static bool Find(this System.Collections.BitArray text, System.Collections.BitArray pattern)
            {
                //... implement your search algorithm here...
            }
            static void Main(string[] args)
            {
                System.Collections.BitArray bitsarr = new System.Collections.BitArray(150);
    
                bool result = bitsarr.Find(new System.Collections.BitArray(new 
    bool[]{true, true, false, true}));
                Console.WriteLine("Result: {0}", result);
            }
        }
    }
