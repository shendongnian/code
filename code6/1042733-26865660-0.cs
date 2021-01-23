    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {
                var dict = new Dictionary<string, string>();
                dict.Add("toto","this is toto");
                dict.Add("tata", "this is tata");
                var keys = dict.Where(p => p.Key == "toto"); // LINQ expression is here
                foreach (var key in keys)
                {
                    Console.WriteLine(key);
                }
                Console.Read();
            }
        }
    }
}
