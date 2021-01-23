    public static void Main(string[] args)
        {
            List<Product> allProducts = InitialiseProductList(allProducts);
            foreach (Product res in allProducts)
            {
                Console.WriteLine("ID:" + " " + res.Id + " " + "Name:" + " " + res.Name);
            }
            Console.ReadKey();
        }
