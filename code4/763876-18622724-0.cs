    using System;
    using System.Collections.Generic;
    
    static class Test
    {
        static void Main()
        {
            string[] original = { "The", "quick", "brown", "fox", "jumped", "over",
                    "the", "lazy", "dog" };
            
            IList<string> segment = new ArraySegment<string>(original, 3, 4);
            Console.WriteLine(segment[2]); // over
            foreach (var word in segment)
            {
                Console.WriteLine(word); // fox jumped over the
            }
        }
    }
