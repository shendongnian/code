    public static string TakeNumDigits(decimal number, int digits)
    {
        string num = number.ToString();
        if (digits > num.Length) 
            throw new ArgumentException("Number of digits must be equal or greater than number.ToString().Length", "digits");
        string decSep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
        int decSepIndex = num.IndexOf(decSep);
        if(decSepIndex == -1 || decSepIndex >= digits)
            return num.Remove(digits);
        else
            return num.Remove(digits + decSep.Length);
    }
