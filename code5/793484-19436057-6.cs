    public class Category
    {
    	public string Name { get; set; }
    	
    	public string UrlName { get; set; }
    	
    	// Other properties..
    	
    	public virtual ICollection<Product> Products { get; set; }
    }
