    using System.Reflection;
    ...
        /// <summary>
        /// Dynamicaly sets property of given object with given value. No type casting is required. Supports COM objects properties.
        /// </summary>
        /// <param name="target">targeted object</param>
        /// <param name="propertyName">property name</param>
        /// <param name="value">desired value</param>
        /// <returns>True if success, False if failure (non existing member)</returns>
        static bool SetProperty(object target, string propertyName, object value)
        {
            Type t = target.GetType();
            if(t.ToString()=="System.__ComObject")
            {
                t.InvokeMember(propertyName, BindingFlags.SetProperty, null, target, new object[] { value });
                return true;
            }
            PropertyInfo propertyInfo = t.GetProperty(propertyName);
            FieldInfo fieldInfo = t.GetField(propertyName);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(target, Convert.ChangeType(value, propertyInfo.PropertyType, null));
                return true;
            }
            if (fieldInfo!=null)
            {
                fieldInfo.SetValue(target, Convert.ChangeType(value, fieldInfo.FieldType, null));
                return true;
            }            
            return false;
        }
    //usage:
    foo bar = new foo();
    SetProperty(bar,"myPropertyOrField","myValue");
