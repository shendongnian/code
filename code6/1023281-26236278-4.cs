    public static string TakeNumDigits(decimal number, int digits, NumberFormatInfo formatProvider = null)
    {
        formatProvider = formatProvider ?? NumberFormatInfo.CurrentInfo;
        string num = number.ToString(formatProvider);
        if (digits >= num.Length)
            return num;
        string decSep = formatProvider.NumberDecimalSeparator;
        int decSepIndex = num.IndexOf(decSep);
       
        if (decSepIndex == -1 || decSepIndex + digits > num.Length)
            return num.Substring(0, digits);
        else
            return num.Substring(0, digits + decSep.Length);
    }
