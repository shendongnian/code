    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            string[] values = { "a", "b", "c" };
            var query = values.Where(x => true);
            Console.WriteLine(query);
            Console.WriteLine(string.Join(";", query));
        }
    }
    
