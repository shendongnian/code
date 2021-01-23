    private Dictionary<string, List<bool>> _properties = new Dictionary<string, List<bool>>();
    
    private void Getconfiguration(PropertyInfo[] properties, object vCapabilities, object fCapabilities, object mCapabilities, List<string> list, string capabilityPath)
            {          
               foreach (var propertyInfo in properties)
               {
                var propertyValue = new List<bool>();
    
                var vValue = propertyInfo.GetValue(vCapabilities, null);
                var fValue = propertyInfo.GetValue(fCapabilities, null);
                var mValue = propertyInfo.GetValue(mCapabilities, null);
    
                var type = GetMemberType(propertyInfo);
    
                if (type != typeof(bool))
                {
                    GetPropertiesForMembers(propertyInfo.PropertyType.GetProperties(), vValue, fValue, mValue, list, Path);
                }
    
                propertyValue.Add(vValue.ToBool());
                propertyValue.Add(fValue.ToBool());
                propertyValue.Add(mValue.ToBool());
    
                _properties.Add(propertyInfo.Name, propertyValue);
            }
            var test = _properties;
        }
