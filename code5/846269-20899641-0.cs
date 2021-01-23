            List<Products> filtterdList=new List<Products>();
            products.Add(new Products { ProductID = "8, 13, 9", CustomerName = "KochLtdCo" });
            products.Add(new Products { ProductID = "9, 13, 9", CustomerName = "KochLtdCo" });
            string searchString = "8";
            filtterdList=  products.Where(x => x.ProductID.Contains(searchString)).ToList();
