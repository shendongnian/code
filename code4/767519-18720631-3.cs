    public class ProductVersions
    {
       //TODO error checking
       public int Version_Id { get; set; }
       public int Major { get; set; }
       public int Minor { get; set; }
       public int Build { get; set; }
              
       public ProductVersions(int major, int minor, int build)
       {
    		Major=major;
    		Minor=minor;
    		Build=build;
       }
       
       public ProductVersions(string version)
       {
       		var tmp = version.Split('.');
    		Major = Int32.Parse(tmp[0]);
    		Minor = Int32.Parse(tmp[1]);
    		Build = Int32.Parse(tmp[2]);
       }
       
       public static bool operator == (ProductVersions a, ProductVersions b)
       {
       		return a.Major==b.Major && a.Minor==b.Minor && a.Build==b.Build;
       }
       
       public static bool operator != (ProductVersions a, ProductVersions b)
       {
       		return !(a==b);
       }
       
       public static bool operator <= (ProductVersions a, ProductVersions b)
       {
       		if (a == b)
    			return true;
    		return a < b;
       }
       
       public static bool operator >= (ProductVersions a, ProductVersions b)
       {
       		if (a == b)
    			return true;
    		return a > b;
       }
       
       public static bool operator < (ProductVersions a, ProductVersions b)
       {
       		if(a.Major==b.Major)
    			if(a.Minor==b.Minor)
    				return a.Build < b.Build;
    			else
    				return a.Minor < b.Minor;
    		else
    			return a.Major < b.Major;
       }
       
       public static bool operator > (ProductVersions a, ProductVersions b)
       {
       		if(a.Major==b.Major)
    			if(a.Minor==b.Minor)
    				return a.Build > b.Build;
    			else
    				return a.Minor > b.Minor;
    		else
    			return a.Major > b.Major;
       }
