    public static class BindingHelper
    {
        // Recursive method that returns value of property (using Reflection)
        // Example: string groupName = GetPropertyValue(user, "UserGroup.GroupName");
        public static object GetPropertyValue(object property, string propertyName)
        {
            object retValue = "";
    
            if (propertyName.Contains("."))
            {
                string leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
    
                PropertyInfo propertyInfo = property.GetType().GetProperties().FirstOrDefault(p => p.Name == leftPropertyName);
    
                if (propertyInfo != null)
                {
                    retValue = GetPropertyValue(
                        propertyInfo.GetValue(property, null),
                        propertyName.Substring(propertyName.IndexOf(".") + 1));
                }
            }
            else
            {
                Type propertyType = property.GetType();
                PropertyInfo propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null);
            }
    
            return retValue;
        }
    }
