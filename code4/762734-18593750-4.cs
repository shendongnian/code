    public static class PropertyExtensions
    {
        public static Object ValueOfProperty(this Object instance, String propertyName)
        {
            PropertyInfo propertyInfo = instance.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(instance);
            }
            return null;
        }
        
        public static Object ValueOfProperty<T>(this Object instance, String propertyName)
        {
            return (T)instance.ValueOfProperty(propertyName);
        }
    }
