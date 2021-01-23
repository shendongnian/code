    public static object GetValue(object entity, string propertyName)
    {
        try
        {
           return entity.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(entity, null);
        }
        catch
        {
            return null;
        }
    }
