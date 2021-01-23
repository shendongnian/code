    public static class ExtensionMethods
    {
        public static string Reverse(this string s)
        {
            return string.Concat(s.Reverse());
            // or:
            // return new string(s.Reverse().ToArray());
        }
    }
