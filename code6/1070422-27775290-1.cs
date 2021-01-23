    using System;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            var x = new string[]
            {
			    "Apple",
			    "Orange",
			    "Banana",
			    "Apple"
            };
    
    		var i = x.GroupBy(c => c.ToUpper()).Select(c => new {c, count = c.Count()}).Count(c => c.count == 1);
    
            Console.WriteLine(i);
        }
    }
