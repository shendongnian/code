            using (var context = new MyAdventureWorksEntities2())
            {
                Product p = context.Products.Where(item => item.ProductID == 1000).First();
                Console.WriteLine(p.Name); // p.Name = "INITIAL NAME"
                UpdateName(p);
                Console.WriteLine(p.Name);
            }
