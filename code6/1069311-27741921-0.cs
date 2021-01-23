    public static string formatDecimalSeparator(this string paramString)
    {
        try
        {
            if (System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator == ",")
                return paramString.Replace(".", ",");
            else
                return paramString.Replace(",", ".");
         }
         catch
         {
             throw;
         }
     }
