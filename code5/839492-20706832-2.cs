    private static Object CreateAndPopulateModelInstance(Type modelInstanceType, IDictionary<string, string> source)
    {
        // this variable will hold the reference to the instance that is to be
        // populated. It will only hold a value, if a property is found that
        // can be populated.
        Object modelInstance = null;
        foreach (PropertyInfo propInfo in modelInstanceType.GetProperties())
        {
            //Identify Custom attribute 
            DataMappingKeyAttribute attribute =  DataMappingKeyAttribute)Attribute.GetCustomAttribute(propInfo, typeof(DataMappingKeyAttribute));
            if (attribute != null && !string.IsNullOrEmpty(attribute.MappingKey))
            {
                if (propInfo.PropertyType.IsPrimitive || propInfo.PropertyType.Equals(typeof(string)))
                {
                    string sourceKey = attribute.MappingKey;
                    if (source.ContainsKey(sourceKey))
                    {
                        // Get propInfo attribute value from Dictionary
                        //var propertySourceValue = source[(propInfo.PropertyType.GetCustomAttribute(typeof(DataMappingKeyAttribute)) as DataMappingKeyAttribute).MappingKey];
                        string sourceValue = source[attribute.MappingKey];
                        // Set propInfo value on the model instance
                        if (CanChangeType(sourceValue, propInfo.PropertyType) && propInfo.CanWrite && (!propInfo.PropertyType.IsClass || propInfo.PropertyType.Equals(typeof(string))))
                        {
                            // create instance if necessary
                            if (modelInstance == null)
                                modelInstance = Activator.CreateInstance(modelInstanceType);
                            propInfo.SetValue(modelInstance, Convert.ChangeType(sourceValue, propInfo.PropertyType), null);
                        }
                    }
                }
            }
            else if (propInfo.PropertyType.IsClass && !propInfo.PropertyType.Equals(typeof(string)) && propInfo.CanWrite)
            {
                Object propertyValue = CreateAndPopulateModelInstance(propInfo.PropertyType, source);
                if (propertyValue != null)
                {
                    // create instance if necessary
                    if (modelInstance == null)
                        modelInstance = Activator.CreateInstance(modelInstanceType);
                    // set property value
                    propInfo.SetValue(modelInstance, propertyValue, null);
                }
            }
        }
        return modelInstance;
    }
