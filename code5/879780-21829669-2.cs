    public static class StrExt
    {
        public static int IntOrDefault(this string str, int defaultValue = 0)
        {
            return String.IsNullOrEmpty(str) || !str.Any(Char.IsDigit) ? defaultValue : Int32.Parse(str);
        }
    }
    ...
    g.Select(s => s[headers.IndexOf("columnToSum")].IntOrDefault()).Sum();
