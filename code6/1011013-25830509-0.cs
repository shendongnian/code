    using ConsoleApplication3;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
    
        private static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { ProductId = "abc", Type = "Normal" });
            products.Add(new Product { ProductId = "def", Type = "Normal" });
            products.Add(new Product { ProductId = "ghi", Type = "VIP" });
            products.Add(new Product { ProductId = "jkl", Type = "Group" });
    
            var result = from p in products
                         group p by p.Type into g
                         orderby g.Key
                         select new { Key = g.Key, Count = g.Count() };
    
            foreach (var r in result)
            {
                Console.Write(string.Format("Type: {0} Count: {1}", r.Key, r.Count));
            }
    
        }
    }
