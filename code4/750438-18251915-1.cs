    public static bool IsInteger(this string s)
    {
       if (String.IsNullOrEmpty(s))
           return false;
       int i;
       return Int32.TryParse(s, out i);
    }
