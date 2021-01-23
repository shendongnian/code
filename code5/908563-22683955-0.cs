    using System.Reflection;
    public static class ExtensionMethods
    {
        public static bool StringPropertiesEmpty(this object value)
        {
            foreach (PropertyInfo objProp in value.GetType().GetProperties())
            {
                if (objProp.CanRead)
                {
                    object val = objProp.GetValue(value, null);
                    if (val.GetType() == typeof(string))
                    {
                        if (val == "" || val == null)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
