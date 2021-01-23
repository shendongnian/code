            List<Products> products = new List<Products>();
            List<Products> filtterdList=new List<Products>();
            products.Add(new Products { ProductID = "8, 13, 9", CustomerName = "KochLtdCo" });
            products.Add(new Products { ProductID = "89, 13, 9", CustomerName = "KochLtdCo" });
            string searchString = "8";
            filtterdList = products.Where(x=>SplitNumber(x.ProductID,8)).ToList();
            Console.WriteLine(filtterdList.Count);
            Console.ReadLine();
        }
      static  bool SplitNumber(string numbers,int numbertoFine)
        {
            int[] productId = numbers.Split(',').Select(int.Parse).ToArray();
            return productId.Any(x => x == numbertoFine);
        }
