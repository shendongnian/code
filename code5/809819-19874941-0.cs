    using System;
    using System.Collections.Generic;
    using System.Linq;            
    
    var amount = new List<double>() { 2.5, 1.5, 3.5, 5.5 };
                var sum = amount.Sum();
                Console.WriteLine(sum);
    
                var highest3 = amount.OrderByDescending(a => a).Take(3);
    
                var i = 1;
                foreach (var d in highest3)
                {
                    Console.WriteLine("{0} is position {1}",d,i);
                    i++;
                }
    
                Console.ReadLine();
