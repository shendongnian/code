        static void Main(string[] args)
        {
            DAL dal = new DAL();
            var products = dal.GetInitialProducts().ToList();
            foreach (Product p in products)
            {
                Console.WriteLine("{0} {1} {2} {3}", p.Name, p.Id, p.Description, p.ListPrice);
            }
            dal.SaveProducts(products);
            IEnumerable<Product> retrievedProducts = dal.GetProducts();
            Console.WriteLine("\nRetrieved Products");
            foreach (Product p in retrievedProducts)
            {
                Console.WriteLine("{0} {1} {2} {3}", p.Name, p.Id, p.Description, p.ListPrice);
            }
            Console.ReadLine();
        }
