    using System.Reflection;
    ...
    static bool SetProperty(object target, string propertyName, object value)
    {
        PropertyInfo propertyInfo = target.GetType().GetProperty(propertyName);
        if (propertyInfo == null)
        { return false; }
        propertyInfo.SetValue(target, Convert.ChangeType(value, propertyInfo.PropertyType, null));
        return true;
    }
