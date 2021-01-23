    public static bool IsNumber(this string s)
    {
       int i;
       return Int32.TryParse(s, out i);
    }
