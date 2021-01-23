    using System;
     
    namespace GetOrElse
    {
    	public static class GetOrElseExtension
    	{
    		public static T GetOrElse<T>(this Nullable<T> instance, T orElse) where T: struct
    		{
    			if (instance == null)
    				return orElse;
    			
    			return instance.Value;
    		}
    	}
    }
