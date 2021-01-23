    // using reflection to get the object's property value
    public static String PropertyHasValue(object obj, string propertyName)
    {
        try
        {
            if (obj != null)
            {
                PropertyInfo prop = obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
                if (prop != null)
                {
                    string sVal = String.Empty;
                    object val = prop.GetValue(obj, null);
                    if (prop.PropertyType != typeof(System.DateTime?))
                        sVal = Convert.ToString(val);
                    else // format the date to contain only the date portion of it
                        sVal = Convert.ToDateTime(val).Date.ToString("d"); ;
                    if (sVal != null)
                    {
                        return sVal;
                     }
                 }
            }
            return null;
        }
        catch
        {
            return null;
        }
    }
