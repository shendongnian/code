    public static void MergeProperty(PropertyInfo pi, ExpandoObject source, object target)
    {
        Type propType = pi.PropertyType;
    
        // dont recurse for value type, Nullable<T> and strings
        if (propType.IsValueType || propType == typeof(string))
        {
            var sourceVal = source.First(kvp => kvp.Key == pi.Name).Value;
            if(sourceVal != null)
                pi.SetValue(target, sourceVal, null);
        }
        else // recursively map inner class properties
        {
            var props = propType.GetProperties(BindingFlags.Public |
                                                      BindingFlags.NonPublic |
                                                      BindingFlags.Instance);
    
            foreach (var p in props)
            {
                var sourcePropValue = source.First(kvp => kvp.Key == pi.Name).Value;
                var targetPropValue = pi.GetValue(target, null);
                                       
                if (sourcePropValue != null)
                {
                    if (targetPropValue == null) // replace
                    {
                        pi.SetValue(target, source.First(kvp => kvp.Key == pi.Name).Value, null);
                    }
                    else
                    {
                        MergeProperty(p, sourcePropValue, targetPropValue);
                    }
                }
            }
                            
        }
    }
    
    public static void MergeProperty(PropertyInfo pi, object source, object target)
    {
        Type propType = pi.PropertyType;
        PropertyInfo sourcePi = source.GetType().GetProperty(pi.Name);
    
        // dont recurse for value type, Nullable<T> and strings
        if (propType.IsValueType || propType == typeof(string)) 
        {
            var sourceVal = sourcePi.GetValue(source, null);
            if(sourceVal != null)
                pi.SetValue(target, sourceVal, null);
        }
        else // recursively map inner class properties
        {
            var props = propType.GetProperties(BindingFlags.Public |
                                                      BindingFlags.NonPublic |
                                                      BindingFlags.Instance);
    
            foreach (var p in props)
            {
                var sourcePropValue = sourcePi.GetValue(source, null);
                var targetPropValue = pi.GetValue(target, null);
                                       
                if (sourcePropValue != null)
                {
                    if (targetPropValue == null) // replace
                    {
                        pi.SetValue(target, sourcePi.GetValue(source, null), null);
                    }
                    else
                    {
                        MergeProperty(p, sourcePropValue, targetPropValue);
                    }
                }
            }
                            
        }
    }
