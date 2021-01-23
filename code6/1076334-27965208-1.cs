    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace q6._2
    {
        class Program
        {
            static void Main(string[] args)
            {
                // ReadProductFile() <- fills all the 
                List<Product> productContents = ReadProductFile();
                ReadSalesAndMergeWithProducts(ref productContents);
                
                foreach (Product p in productContents)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.ReadLine();
            }
            private static void ReadSalesAndMergeWithProducts(ref List<Product> productContents)
            {
                string[] salesDetails = File.ReadAllLines(GetDataDirectory() + "\\data\\salesdata.csv");
                int smallestNr = GetSmallestOfTwo(salesDetails.Length, productContents.Count);
                for (int i = 1; i < smallestNr; i++)
                {
                    productContents.ElementAt(i).WeeklySales = Convert.ToInt32(salesDetails[i].Split(',')[1]);
                }
            }
            /// <summary>
            /// shortend GetDataDirectory
            /// </summary>
            /// <returns></returns>
            public static string GetDataDirectory()
            {
                return System.IO.Directory.GetCurrentDirectory().Replace("bin\\Debug", "");
            }
            /// <summary>
            /// ReadProductFile
            /// </summary>
            /// <returns>List<</returns>
            public static List<Product> ReadProductFile()
            {            
                // remove the filename string and directly pass it to the read all lines
                string[] productDetails = File.ReadAllLines(GetDataDirectory() + "\\data\\productdetails.csv");
            
                // no need to classify the size here since it will return from product details. (no harm though)
                string[] lineDetails;// = new string[5];
                // create a new product object
                List<Product> productObj = new List<Product>();
                // loop over the product details
                for (int i = 1; i < productDetails.Length; i++)
                {
                    // split on comma char
                    lineDetails = productDetails[i].Split(',');
                    // create new product
                    Product newProduct = new Product(lineDetails[0], lineDetails[1], lineDetails[2], Convert.ToDecimal(lineDetails[3]), Convert.ToInt32(lineDetails[4]));
                    // add product to list
                    productObj.Add(newProduct);
                }
                // return List<Product>
                return productObj;
            }
            /// <summary>
            /// GetSmallestOfTwo
            /// </summary>
            /// <param name="a">int</param>
            /// <param name="b">int</param>
            /// <returns>int</returns>
            public static int GetSmallestOfTwo(int a, int b)
            {
                return (a <= b) ? a : b;
            }
        }
        /// <summary>
        /// Product class
        /// </summary>
        class Product
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int StockAvailable { get; set; }
            public int WeeklySales { get; set; }
            public Product(string id, string name, string description, decimal price, int stockavailable)
            {
                ID = id;
                Name = name;
                Description = description;
                Price = price;
                StockAvailable = stockavailable;
            }
            public Product(string id, string name, string description, decimal price, int stockavailable, int weeklysales)
            {
                ID = id;
                Name = name;
                Description = description;
                Price = price;
                StockAvailable = stockavailable;
                WeeklySales = weeklysales;
            }
            public String ToString()
            {
                return "ID: " + ID + " Name: " + Name + " Description: " + Description +
                       " Price:" + Price + "StockAvailable: " + StockAvailable + " WeeklySales: " + WeeklySales;
            }
        }
    }
