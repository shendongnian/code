    public static class StringExt
    {
        public static bool ContainsAnyOf(this string self, params string[] strings)
        {
            return strings.Any(self.Contains);
        }
    }
