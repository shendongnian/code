    public static class StringExtensions {
        public static string TrimWithEllipses(this string s, int left) {
            if (s.Length < left)
                return s;
            else
                return s.Substring(0, left) + "...";
        }
    }
