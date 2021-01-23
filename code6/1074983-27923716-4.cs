    using System.Web;
    
    namespace SomeMVC
    {
    	public static class HelperMethods
    	{
    		public static string GetLayoutId()
    		{
    			return (string) HttpContext.Current.Session["LayoutId"];
    		}
    
    		public static void SetLayoutId(string id)
    		{
    			HttpContext.Current.Session["LayoutId"] = id;
    		}
    	}
    }
