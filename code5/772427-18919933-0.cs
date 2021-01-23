    var propertyName = GetPropertyName(owner.GetType(), owner, typeof(YourAttribute));
    public static string GetPropertyName(Type entityType, object entity, Type attributeType)
    {
        if (entity == null) return null;
        var propertyInfo = GetPropertyInfo(entityType, attributeType);
        return propertyInfo == null ? null : propertyInfo.Name;
    }
    public static PropertyInfo GetPropertyInfo(Type entityType, Type attributeType)
    {
        return entityType.GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(false)
            .Count(x => x.GetType() == attributeType) > 0);
    }
