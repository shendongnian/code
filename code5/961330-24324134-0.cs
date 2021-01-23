    public class MyDataAccessLayer
    {
    	public IEnumerable<Product> GetProducts()
    	{
    		return DbContext.Products.Select(x => new Product 
    		{ 
    			Price = Context.Price.FirstOrDefault().OrderByDescending(c => c.Id)
    		};
    	}
    	
    	public Product GetProduct(string id)
    	{
    		var product = DbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
    		   product.Price = Context.Price.FirstOrDefault().OrderByDescending(c => c.Id);
            }
            return product;
    	}
    }
