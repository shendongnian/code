    var tmp = Helper.Validate<put your type here>(temp);
    var variable = !variable.Equal(tmp) ? tmp : variable 
    EditorUtility.SetDirty(target);
                   
  
    using System.ComponentModel;
    namespace CommonLib.Helpers
    {
     public static  partial class Helper
     {
    	 public static T Validate<T>(object param)
    	{
    		return TryParse<T>(param);
    	}
    
    	
           private static T TryParse<T>(object inValue)
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
    
                try
                {
                   return (T)converter.ConvertFromString(inValue.ToString().Trim());
                }
                catch
                {
                    return default(T);
                }
            }
    	
     }
    }
    	
