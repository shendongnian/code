    public class Product
    {
    	public string Label { get; set; }
    	public decimal Price { get; set; }
    	public decimal DiscountPercent { get; set; }
    	public decimal DiscountAmount { get; set; }
    
    	public static List<Product> GetProducts()
    	{
    		var list = new List<Product>
    			{
    				new Product {Label = "Product 1", Price = 1000},
    				new Product {Label = "Product 2", Price = 2000}
    			};
    
    		return list;
    	}
    }
