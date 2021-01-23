    public static class StringExtensions 
    {// CurrencyType is your currency type, guessing double or decimal?
     public static string ToCurrencyString(this CurrencyType value, IFormatInfo format)
     {
        return value.ToString("C", format).Replace((char) 32, (char) 160);
     }
    }
