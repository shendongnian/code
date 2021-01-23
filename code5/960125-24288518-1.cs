        public static void UpdateName(Product p)
        {
            using (var context = new MyAdventureWorksEntities2())
            {
                p = context.Products.Where(item => item.ProductID == 1003).First();
                // p.Name = "ANOTHER PRODUCT NAME"
            }
        }
