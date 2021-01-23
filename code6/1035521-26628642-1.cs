    static MyClass()
    {
        PropertyMap = new Dictionary<string, Func<ArisingViewModel,string>>();
        var myType = typeof(ArisingViewModel);
        foreach (var propertyInfo in myType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            if (propertyInfo.GetGetMethod() != null)
            {
                var attr = propertyInfo.GetCustomAttribute<FieldNameAttribute>();
                if (attr == null)
                    continue;
                PropertyInfo info = propertyInfo;
                PropertyMap.Add(attr.FieldName, obj => (string)info.GetValue(obj,null));
            }
        }
    }
    public static object GetPropertyValue(ArisingViewModel obj, string field)
    {
        Func<ArisingViewModel,string> prop;
        if (PropertyMap.TryGetValue(field, out prop)) {
           return prop(obj);
        }
        return null; //Return null if no match
      }
