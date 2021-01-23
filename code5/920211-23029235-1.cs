        public class ProductRepository : IProductRepository
        {
    	    List<Product> data = new List<Product>
            {
    			new Product { Name = "FootBall", Price=25 },
    			new Product { Name = "Surf board", Price=179 },
    			new Product { Name = "Running shoes", Price=25 }
    		};
    		
            public IQueryable<Product> Products()
            {
    
              return this.data.AsQueryable;
    
            }
    
            public void AddProducts(Product product)
            {
    			this.data.Add(product);
            }
        }
