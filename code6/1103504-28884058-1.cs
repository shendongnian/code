    private static Dictionary<string, object> GetValues(FileInfo o)
    {
        var values = new Dictionary<string, object>();
    
        foreach (var memberInfo in o.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public))
        {
            var propertyInfo = memberInfo as PropertyInfo;
            var fieldInfo = memberInfo as FieldInfo;
            if (propertyInfo != null)
            {
                values.Add(propertyInfo.Name, propertyInfo.GetValue(o, null));
            }
            if (fieldInfo != null)
            {
                values.Add(fieldInfo.Name, fieldInfo.GetValue(o));
            }
        }
    
        return values;
    }
