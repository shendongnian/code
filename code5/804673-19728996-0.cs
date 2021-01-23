    public static class StringExtensions {
        public bool TrimAndEqualsInsensitive (this string str1, string str2) {
            return str1.Trim().Equals(str2.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
