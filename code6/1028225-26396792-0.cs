    public static int? ConvertNumericStringObj(string strValue)
    {
        int x;
        if (Int32.TryParse(strValue , out x)
            return x;
        return null;
    }
