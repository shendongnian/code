      public IEnumerable<Product> GetProducts(params int[] selectCategory )
       {               
         return repository.Query<Category>       
        (p => selectCategory.Contains(p.ID)).SelectMany(p => p.Products).ToList()
                         
       }
