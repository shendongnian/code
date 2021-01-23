    public class PropertyInfoWithValue
    {
        PropertyInfo propertyInfo;
        public PropertyInfoWithValue(PropertyInfo propertyInfo, object value)
        {
            this.propertyInfo = propertyInfo;
            SetValue(value);
        }
        public object Value { get; private set; }
        public void SetValue(object value)
        {
            this.Value = value;
        }
        public static explicit operator PropertyInfoWithValue(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                return null;
            // supply a default value, because we don't know it yet.
            object value = null;
            if (propertyInfo.PropertyType.IsValueType)
                value = Activator.CreateInstance(propertyInfo.PropertyType);
            return new PropertyInfoWithValue(propertyInfo, value);
        }
        public static explicit operator PropertyInfo(PropertyInfoWithValue
                                                     propertyInfoWithValue)
        {
            if (propertyInfoWithValue == null)
                return null;
            return propertyInfoWithValue.propertyInfo;
        }
    }
