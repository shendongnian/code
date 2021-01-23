    public static string TakeNumDigits(decimal number, int digits, NumberFormatInfo formatProvider = null)
    {
        formatProvider = formatProvider ?? NumberFormatInfo.CurrentInfo;
        string num = number.ToString(formatProvider);
        if (digits > num.Length) 
            throw new ArgumentException("Number of digits must be equal or greater than number.ToString().Length", "digits");
        string decSep = formatProvider.NumberDecimalSeparator;
        int decSepIndex = num.IndexOf(decSep);
        if(decSepIndex == -1 || decSepIndex >= digits)
            return num.Substring(0, digits);
        else
            return num.Remove(digits + decSep.Length);
    }
