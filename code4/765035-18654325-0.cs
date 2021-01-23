    void Main()
    {
    	List<App> apps;
    	List<App> filteredapps;
    	
    	var query=apps.Intersect(filteredapps,new AppComparer());
    	
    	
    }
    public class App
    {
       public string Appname;
       public string Appcode;
    
    }
    class AppComparer : IEqualityComparer<App>
    {
    	 
    	public bool Equals(App x, App y)
	    {
 
		if (Object.ReferenceEquals(x, y)) return true;
		 
		if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
			return false;
		 
		return x.Appname == y.Appname && x.Appcode == y.Appcode;
	}
	// If Equals() returns true for a pair of objects  
	// then GetHashCode() must return the same value for these objects. 
	public int GetHashCode(App product)
	{
		//Check whether the object is null 
		if (Object.ReferenceEquals(App, null)) return 0;
		//Get hash code for the Name field if it is not null. 
		int hashProductName = product.Appname == null ? 0 : product.Appname.GetHashCode();
		//Get hash code for the Code field. 
		int hashProductCode = product.Appcode.GetHashCode();
		//Calculate the hash code for the product. 
		return hashProductName ^ hashProductCode;
	}
    }
