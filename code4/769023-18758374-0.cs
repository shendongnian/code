    private static IList<BindingInfo> getReflectPropertyDescriptorInfo()
            {
                var results = new List<BindingInfo>();
    
                var reflectTypeDescriptionProvider = typeof(PropertyDescriptor).Module.GetType("System.ComponentModel.ReflectTypeDescriptionProvider");
                var propertyCacheField = reflectTypeDescriptionProvider.GetField("_propertyCache",
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (propertyCacheField == null)
                    throw new NullReferenceException("`ReflectTypeDescriptionProvider._propertyCache` not found");
    
                var propertyCacheItems = propertyCacheField.GetValue(null) as Hashtable;
                if (propertyCacheItems == null)
                    return results;
    
                var valueChangedHandlersField = typeof(PropertyDescriptor).GetField("valueChangedHandlers",
                    BindingFlags.Instance | BindingFlags.NonPublic);
    
                if (valueChangedHandlersField == null)
                    return results;
    
                foreach (DictionaryEntry entry in propertyCacheItems)
                {
                    var properties = entry.Value as PropertyDescriptor[];
                    if (properties == null)
                        continue;
    
                    foreach (var property in properties)
                    {
                        var valueChangedHandlers = valueChangedHandlersField.GetValue(property) as Hashtable;
                        if (valueChangedHandlers != null && valueChangedHandlers.Count != 0)
                            results.Add(new BindingInfo
                                {
                                    TypeName = entry.Key.ToString(),
                                    PropertyName = property.Name,
                                    HandlerCount = valueChangedHandlers.Count
                                });
                    }
                }
    
                return results;
            }
