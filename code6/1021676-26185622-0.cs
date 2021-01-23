    public static T ConvertToClass<T>(this Dictionary<string, object> model)
    {
        Type type = typeof(T);
        var obj = Activator.CreateInstance(type);
        foreach (var item in model)
        {                              
           PropertyInfo property = type.GetProperty(item.Key);
           Type propertyType = property.PropertyType;
           property.SetValue(obj, item.Value.ConvertToType(propertyType));
        }
        return (T)obj;
    }
    public static object ConvertToType(this string value, Type t)
    {
         return Convert.ChangeType(value, t);
    } 
