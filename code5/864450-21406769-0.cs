    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            Product p1 = new Product(false, 99);
            Product p2 = new Product(true, 99);
            Product p3 = new Product(true, 101);
            Product p4 = new Product(true, 110);
            Product p5 = new Product(false, 110);
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);
            list.Add(p5);
            double priceLimit = 100;
            // We have OnSaleSpecificationForProduct &&
            //         (PriceGreaterThanSpecificationForProduct || PriceGreaterThan105)
            var specification = 
                OnSaleSpecificationForProduct()
                    .And(PriceGreaterThanSpecificationForProduct(priceLimit)
                             .Or(PriceGreaterThan105()));
            List<Product> selectedList = ProductFilterHelper.GetProductsBasedOnInputFilters(list, specification);
            Console.ReadKey();
        }
    }
