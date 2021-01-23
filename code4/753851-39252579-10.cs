    public static string ConvertDigitChar(this string str, CultureInfo source, CultureInfo destination)
    {
        for (int i = 0; i <= 9; i++)
        {
            str = str.Replace(source.NumberFormat.NativeDigits[i], destination.NumberFormat.NativeDigits[i]);
        }
        return str;
    }
    
    public static string ConvertDigitChar(this int digit, CultureInfo destination)
    {
        string res = digit.ToString();
        for (int i = 0; i <= 9; i++)
        {
            res = res.Replace(i.ToString(), destination.NumberFormat.NativeDigits[i]);
        }
        return res;
    }
