    // Base class with price property, could also be an shared interface
    public abstract class Product
    {
    	public decimal Price{get;set;}
    }
    
    public class Ring : Product
    {
    	
    }
    public class Bag : Product
    {
    	
    }
    
    // Some test data
    var myUnsortedArray = new Product[]{new Ring{Price = 1.2m}, new Bag{Price=2.5m}};
    
    // Easy sort with LINQ
    var sortedProducts = myUnsortedArray.OrderBy(p => p.Price).ToArray();
    var sortedProductsDescending = myUnsortedArray.OrderByDescending(p => p.Price).ToArray();
