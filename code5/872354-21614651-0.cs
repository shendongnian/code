    public static object[] GetAttributes(Type type, string propertyName)
    {
         var prop = type.GetProperty(propertyName);
         if (prop != null)
         {
             return prop.GetCustomAttributes(false);
         }
         else
         {
             return null;
         }
    }
