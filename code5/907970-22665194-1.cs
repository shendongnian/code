    [DefaultValue("This is my default")]
    public string MyProperty
    {
        get
        {
            string value = this.db.getMyProperty();
            if (value == null)
            {
                // get property name from GetCurrentMethod.
                // use the SubString to remove the "get_" that comes from .net internals
                var propertyName = MethodBase.GetCurrentMethod().Name.Substring(4);
                // keep your method
                var myPropertyInfo = this.GetType().GetProperty(propertyName);
                var myAttributeInfo = myPropertyInfo.GetCustomAttribute(
                    typeof (DefaultValueAttribute)) as DefaultValueAttribute;
                if (myAttributeInfo != null)
                    value = myAttributeInfo.defaultValue;
            }
            return value;
        }
    }
