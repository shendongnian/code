    using System.Web;
    
    namespace SomeMVC
    {
    	public static class HelperMethods
    	{
    		public static int? GetLayoutId()
    		{
    			return (int?)HttpContext.Current.Session["LayoutId"];
    		}
    
    		public static void SetLayoutId(int? id)
    		{
    			HttpContext.Current.Session["LayoutId"] = id;
    		}
    	}
    }
