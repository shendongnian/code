    public static object[] GetAttributes(Type type, string propertyName,BindingFlags flags)
    {
         var prop = type.GetProperty(propertyName,flags);
         if (prop != null)
         {
             return prop.GetCustomAttributes(false);
         }
         else
         {
             return null;
         }
    }
