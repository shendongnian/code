    List<Product> list = new List<Product>() { 
                    new Product() { ID = 1, Description = "BBB" , Price = 10},
                    new Product() { ID = 2, Description = "CCC" , Price = 40},
                    new Product() { ID = 3, Description = "DDD" , Price = 60}};
                List<Product> newList = new List<Product>();
                newList.Add(new Product() { ID = list[0].ID ,  Description = string.Join(", ", list.Select(a => a.Description).ToArray()), 
                    Price = list.Select(a => a.Price).Sum()});
