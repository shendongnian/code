    using System.Reflection;
    ...
    /// <summary>
    /// Dynamicaly sets property of given object with given value. No type casting is required.
    /// </summary>
    /// <param name="target">targeted object</param>
    /// <param name="propertyName">property name</param>
    /// <param name="value">desired value</param>
    /// <returns>True if success, False if failure (non existing property)</returns>
    static bool SetProperty(object target, string propertyName, object value)
    {
        PropertyInfo propertyInfo = target.GetType().GetProperty(propertyName);
        if (propertyInfo == null)
        { return false; }
        propertyInfo.SetValue(target, Convert.ChangeType(value, propertyInfo.PropertyType, null));
        return true;
    }
    //usage:
    foo bar = new foo();
    SetProperty(bar,"myProperty","myValue");
