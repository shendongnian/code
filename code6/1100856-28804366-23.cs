    public static class GetDefaultHelper
    {
    	public static T GetDefaultInstance<T>()
    	{
    	  var propInfo = typeof(T).GetProperty("Default", BindingFlags.Public | BindingFlags.Static);
    	  return (propInfo != null) ?  (T)propInfo.GetValue(null) : default(T);		
    	}
    }
