    using System;
    using System.Linq;
    
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                var products = new Product[] {
                    new Product(){ Name = "Product 1", Quantity = 1 },
                    new Product(){ Name = "Product 2", Quantity = 2 },
                    new Product(){ Name = "Product -1", Quantity = -1 },
                    new Product(){ Name = "Product 3", Quantity = 3 },
                    new Product(){ Name = "Product 4", Quantity = 4 }
                };
    
                int? myInt = null;
    
                foreach (var prod in products.Where(p => p.Quantity == myInt.GetValueOrDefault(-1)))
                {
                    Console.WriteLine($"{prod.Name} - {prod.Quantity}");
                }
    
                Console.ReadKey();
            }
        }
    
        public class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
    }
