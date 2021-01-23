    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, int>
            {
                { "first", 10 },
                { "second", 1 },
                { "third", 100000 }
            };
            
            foreach (var entry in data)
            {
                Console.WriteLine("{0,-20}{1,8}", entry.Key, entry.Value);
            }
        }
    }
