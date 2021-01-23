    public class PermissionManager
    {
        public static Dictionary<string, IEnumerable<string>> AvailablePermissions { get; set; }
    	public static bool? Can(User user, string permission)
    	{
    	    // check DB
    		return ALLOWED ? true : (DENIED ? false : null);
    	}
    }
    
    public class MyPlugin : IPlugin
    {
        public void Init()
    	{
    	    PermissionManager.AvailablePermissions["MyPlugin"] = 
                new List<string>() { "Permission1", "Permission2" };
    	}
    	
    	public void DoWork()
    	{
    	    if (PermissionManager.Can(user, "Permission1") != true)
    		    throw new NotAllowedException();
    		// do work
    	}
    }
