    using System;
    public class Test 
    {
        public static void Main() 
        {
            #if (NET45) 
                Console.WriteLine("NET45 targeted");
            #else
                Console.WriteLine("NET45 not targeted");
            #endif
        }
    }
