    public class PropertyValue
    {
        private PropertyInfo propertyInfo;
        private object baseObject;
        public PropertyValue(PropertyInfo propertyInfo, object baseObject)
        {
            this.propertyInfo = propertyInfo;
            this.baseObject = baseObject;
        }
        public string Name
        {
            get { return propertyInfo.Name; }
        }
        public Type PropertyType
        {
            get { return propertyInfo.PropertyType; }
        }
        public object Value
        {
            get
            {
                var retVal = propertyInfo.GetValue(baseObject, null);
                if (PropertyType.IsEnum)
                {
                    retVal = retVal.ToString();
                }
                return retVal;
            }
            set
            {
                if (PropertyType.IsEnum)
                {
                    value = Enum.Parse(propertyInfo.PropertyType, value.ToString());
                }
                propertyInfo.SetValue(baseObject, value, null);
            }
        }
    }
