    private static SearchableAttribute GetNestedSearchableAttribute(PropertyInfo propertyInfo)
    {
        var attribute = (SearchableAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(SearchableAttribute), true);
        if (attribute == null)
        {
            return propertyInfo
                .PropertyType
                .GetProperties()
                .Select(GetNestedSearchableAttribute)
                .FirstOrDefault(attrib => attrib != null);
        }
            
        attribute.SearchablePropertyName = propertyInfo.Name;
        return attribute;
    }
