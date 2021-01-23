    using System.Reflection;
    ...
    /// <summary>
    /// Dynamicaly sets property or field of given object with given value. No type casting is required.
    /// </summary>
    /// <param name="target">targeted object</param>
    /// <param name="propertyName">property or field name</param>
    /// <param name="value">desired value</param>
    /// <returns>True if success, False if failure (non existing property or field)</returns>
    static bool SetProperty(object target, string propertyName, object value)
    {
        PropertyInfo propertyInfo = target.GetType().GetProperty(propertyName);
        FieldInfo fieldInfo = target.GetType().GetField(propertyName);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(target, Convert.ChangeType(value, propertyInfo.PropertyType, null));
            return true;
        }
        if (fieldInfo != null)
        {
            fieldInfo.SetValue(target, Convert.ChangeType(value, fieldInfo.FieldType, null));
            return true;
        }            
        return false;
    }
    //usage:
    foo bar = new foo();
    SetProperty(bar,"myPropertyOrField","myValue");
