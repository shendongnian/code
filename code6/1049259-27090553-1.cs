    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    namespace JSONExample
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                LoadJson();
            }
    
            public static void LoadJson()
            {
                using (StreamReader r = new StreamReader(@"C:\Users\Derek\Desktop\JSON.txt"))
                {
                    string json = r.ReadToEnd();
                    List<Product> dataFile = JsonConvert.DeserializeObject<List<Product>>(json);
    
                    foreach (var product in dataFile.ToArray())
                    {
                        Console.WriteLine("Type: {0} - Price: {1} - Quantity: {2}", product.ProductType, product.Price,
                            product.Qty);
                    }
                }
    
                Console.ReadKey();
            }
        }
    
    
    
        public class Product
        {
            public int Qty { get; set; }
            public string ProductType { get; set; }
            public float Price { get; set; }
        }
    
    }
