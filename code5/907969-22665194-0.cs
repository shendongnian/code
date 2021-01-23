    [DefaultValue("This is my default")]
    public string MyProperty
    {
        get
        {
            string value = this.db.getMyProperty();
            if (value == null)
            {
                // get property name from GetCurrentMethod.
                var propertyName = MethodBase.GetCurrentMethod().Name;
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
