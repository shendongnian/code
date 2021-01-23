    private static Dictionary<string, Type> GetFields(Type t)
    {
        var fields = new Dictionary<string, Type>();
    
        foreach (var memberInfo in t.GetMembers(BindingFlags.Instance | BindingFlags.Public))
        {
            var propertyInfo = memberInfo as PropertyInfo;
            var fieldInfo = memberInfo as FieldInfo;
            if (propertyInfo != null)
            {
                fields.Add(propertyInfo.Name, propertyInfo.PropertyType);
            }
            if (fieldInfo != null)
            {
                fields.Add(fieldInfo.Name, fieldInfo.FieldType);
            }
        }
    
        return fields;
    }
