    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            var doublesarray = new double[] { 0, 2, 4, 5, 7, 8, 2, 4, 6 };
    
            Log(doublesarray);
    
            IEnumerable<double> slicedarray = doublesarray.Skip(5).Take(4);
    
            Log(slicedarray);
        }
    
        static void Log(IEnumerable<double> doublesarray)
        {
            foreach (var d in doublesarray)
                Console.WriteLine(d);
            Console.WriteLine("-----");
        }
    }
