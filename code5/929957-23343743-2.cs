    public static void SetValue(object entity, string propertyName, object value)
    {
                try
                {
                    PropertyInfo pi = entity.GetType().GetProperty(propertyName);
                    Type t = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                    object safeValue = (value == null) ? null : Convert.ChangeType(value, t);
                    pi.SetValue(entity, safeValue, null);
                }
                catch (InvalidCastException ex)
                {
                    //Handle casting between different assemblies...
                    try
                    {
                        PropertyInfo pi = entity.GetType().GetProperty(propertyName);
                        Type t = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                        object safeValue = (value == null) ? null : Activator.CreateInstance(t, value);
                        pi.SetValue(entity, safeValue, null);
                    }
                    catch
                    {
    
                    }
                }
                catch
                {
    
                }
    
                return;
    }
