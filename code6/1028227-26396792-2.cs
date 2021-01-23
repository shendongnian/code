    public static T? ConvertNumericStringObj<T>(string strValue) 
    {
        if (string.IsNullOrEmpty(strValue))
            return null;
        return (T) Convert.ChangeType(strValue, typeof(T));
    }
