    public static string GetDescription(T fieldName)
    {
        string result;
        FieldInfo fi = typeof(T).GetField(fieldName.ToString());
        if (fi != null)
        {
            try
            {
                object[] descriptionAttrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                DescriptionAttribute description = (DescriptionAttribute)descriptionAttrs[0];
                result = (description.Description);
            }
            catch
            {
                result = null;
            }
        }
        else
        {
            result = null;
        }
        return result;
    }
