    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Sample
    {
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    } 
    public class Program
    {
        public static List<Product> allProducts;
    
        public static void InitialiseMyProducts()
        {
            allProducts = new List<Product>
            {
                new Product(){Id=1,Name="TV"},
                new Product(){Id=2,Name="Bat"},
                new Product(){Id=3,Name="Ball"},
                new Product(){Id=4,Name="Chair"},
            };
        }       
    
        public static void Main(string[] args)
        {
            InitialiseProductList();
            foreach (Product res in allProducts)
            {
                Console.WriteLine("ID:" + " " + res.Id + " " + "Name:" + " " + res.Name);
            }
            Console.ReadKey();
        }
        }
    }
