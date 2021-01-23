    public static object GetDeepPropertyValue(object src, string propName)   
    {     
         return src.GetType().GetProperty(propName).GetValue(src, null); 
    }
  
