    static class StringExtensions
    {
        public static string TrimNullTerminatedString(this string s)
        {
            if (s == null)
                throw new NotImplementedException();
            int i = s.IndexOf('\0');
            if (i >= 0)
                return s.Substring(0, i);
            return s;
        }
    }
