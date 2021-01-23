    public class DirectoryHelpers
    {
    	public static string FindPhysicalRootDirectory(Page p)
    	{
    		string rootDir;
    		//rootDir = p.Server.MapPath("/");
    
    		rootDir = p.Server.MapPath("~/");
    		return rootDir;
    	}
    
    	public static string FindVirtualRootDirectory(Page p)
    	{
    		return "~/";
    	}
    	
    }
