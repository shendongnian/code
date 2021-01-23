    public static class StringExtensions 
    {
     public static string ToCurrencyString(this string value, IFormatInfo format)
     {
        return value.ToString("C", format).Replace((char) 32, (char) 160);
     }
    }
